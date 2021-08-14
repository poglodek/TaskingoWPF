using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using TaskingoApp.Exceptions;

namespace TaskingoApp.APICall
{
    public class BaseCall
    {
        private const string Url = "https://localhost:5001/";
        public static string Token = string.Empty;
        private static int MaxCallsInThisSameTime = 3;
        private static int ActiveCalls = 0;

        public static async Task<string> MakeCall(string endpoint, HttpMethod httpMethod, object body)
        {
            if (ActiveCalls > MaxCallsInThisSameTime)
                throw new ToManyCallsException($"To many Calls. Active Calls -> {ActiveCalls}");
            ActiveCalls++;
            var respone = await CallApi(endpoint, httpMethod, body);
            return await CheckResponse(respone);
        }

        private static async Task<HttpResponseMessage> CallApi(string endpoint, HttpMethod httpMethod, object body)
        {
            using var httpClient = new HttpClient();
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Put;
            request.RequestUri = new Uri(Url + endpoint);
            if (body != null) request.Content = new StringContent(JsonSerializer.Serialize(body));
            if (!string.IsNullOrEmpty(Token)) httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var respone = await httpClient.SendAsync(request);
            --ActiveCalls;
            return respone;
        }

        private static async Task<string> CheckResponse(HttpResponseMessage respone)
        {
            if (respone.IsSuccessStatusCode)
            {
                var odp = await respone.Content.ReadAsStringAsync();
                return odp;
            }
            if (respone.StatusCode == System.Net.HttpStatusCode.NoContent) throw new NotFound("We don't found this. Please try again.");
            if (respone.StatusCode == System.Net.HttpStatusCode.Forbidden ||
                respone.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new Unauthorized("Unauthorized. If you should have access, please contact with admin ");
            if (respone.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                ((int)respone.StatusCode) >= 500) throw new ApiServerError("Server ErrorView. Please contact with admin.");
            if (respone.StatusCode == System.Net.HttpStatusCode.Conflict) throw new Conflict("Conflict with data. Please contact with admin.");
            throw new OtherRespone(respone.ReasonPhrase);
        }
    }
}
