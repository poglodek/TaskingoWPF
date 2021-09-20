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
        private static readonly string Url = Properties.Settings.Default.ApiUrl;
        public static string Token = string.Empty;
        private static int MaxCallsInThisSameTime = 3;
        private static int _activeCalls;

        public static async Task<string> MakeCall(string endpoint, HttpMethod httpMethod, object body)
        {
            if (_activeCalls > MaxCallsInThisSameTime)
                throw new ToManyCallsException($"To many Calls. Active Calls -> {_activeCalls}");
            _activeCalls++;
            var response = await CallApi(endpoint, httpMethod, body);
            return await CheckResponse(response);
        }

        private static async Task<HttpResponseMessage> CallApi(string endpoint, HttpMethod httpMethod, object body)
        {
            using var httpClient = new HttpClient();
            var request = new HttpRequestMessage();
            request.Method = httpMethod;
            request.RequestUri = new Uri(Url + endpoint);
            request.Content = new StringContent(JsonSerializer.Serialize(body));
            if (!string.IsNullOrEmpty(Token)) httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(request);
            --_activeCalls;
            return response;
        }

        private static async Task<string> CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var odp = await response.Content.ReadAsStringAsync();
                return odp;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedException("UnauthorizedException. If you should have access, please contact with admin ");
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) throw new ForbiddenException("Forbidden. If you should have access, please contact with admin ");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                ((int)response.StatusCode) >= 500) throw new ApiServerErrorException("Server InfoPopupView. Please contact with admin.");
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict) throw new ConflictException("ConflictException with data. Please contact with admin.");
            throw new OtherResponseException(response.ReasonPhrase);
        }
    }
}
