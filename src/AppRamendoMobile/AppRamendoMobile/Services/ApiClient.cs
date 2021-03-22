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
    public class ApiClient : IApiClient
    {

        private readonly HttpClient _client;

        public ApiClient() {
            _client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url) {
            try {
                var json = await _client.GetStringAsync(url);
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }
            catch (HttpRequestException httpEx) {
                throw new HttpRequestException(httpEx.Message);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string url) {
            try {

                var responseMessage = await Policy
                    .Handle<Exception>(ex => true)
                    .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await _client.GetAsync(url));

                var content = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> PostAsync<T>(string url) {
            try {

                var responseMessage = await Policy
                    .Handle<Exception>(ex => true)
                    .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await _client.PostAsync(url, null));

                var content = await responseMessage.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(content);
                return result;
                //return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> InsertAsync<T>(T settings, string url) {
            var json = JsonConvert.SerializeObject(settings);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync(url, httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync<T>(T settings, string url) {
            var json = JsonConvert.SerializeObject(settings);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PutAsync(url, httpContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync<T>(string url) {
            var response = await _client.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
