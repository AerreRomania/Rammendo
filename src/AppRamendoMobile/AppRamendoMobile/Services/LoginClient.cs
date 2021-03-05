using AppRammendoMobile.Models;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppRammendoMobile.Services
{
    public class LoginClient : ILoginClient
    {

        private HttpClient _client;

        public LoginClient() {
            _client = new HttpClient();
        }

        public async Task<Angajati> LoginUserAsync(string url) {
            try {
                var request = new HttpRequestMessage(
                                   HttpMethod.Post, url);

                var response = await Policy
                   .Handle<Exception>(ex => true)
                   .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                   .ExecuteAsync(async () => await _client.SendAsync(request));

                if (response.StatusCode != HttpStatusCode.OK) {
                    return null;
                }

                var angajats = await response.Content.ReadAsStringAsync();
                Angajati angajat = JsonConvert.DeserializeObject<Angajati>(angajats);

                return angajat;
            }
            catch (HttpRequestException httpEx) {
                throw new HttpRequestException(httpEx.Message);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
