using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskingoWPF.APICall
{
    public class LoginCall
    {
        private const string URL = @"https://jsonplaceholder.typicode.com/todos/1";
     //   private const string URL = @"https://localhost:5001/";
        private const string endpoint = "login";

        public async Task<string> LogIn()
        {
            using (var webClient = new HttpClient {BaseAddress = new Uri(URL)})
            {
                webClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
                var token = string.Empty;
                try
                {
                    var response = await webClient.GetAsync("");
                 //   var response = await webClient.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsStringAsync();
                    }
                    return token;
                }
                catch
                {
                    return token;

                }
            };
            


        }
    }
}
