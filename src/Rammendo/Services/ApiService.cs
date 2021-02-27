using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Rammendo.Services.Interfaces;
using Polly;
using Newtonsoft.Json;

namespace Rammendo.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;

        public ApiService() {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<T>> GetAll<T>() {

            try {

                var responseMessage = await Policy
                    .Handle<Exception>(ex => true)
                    .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await _client.GetAsync($"{Store.Default.Url}TelliProdoti"));

                var content = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllByFilter<T>(string[] filter) {
            try {

                var responseMessage = await Policy
                    .Handle<Exception>(ex => true)
                    .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await _client.GetAsync($"{Store.Default.Url}TelliProdoti?article={filter[0]}&commessa={filter[1]}"));

                var content = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
