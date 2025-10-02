using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json; 

namespace Enabill.IntegrationLayer
{

    public class RESTIntegrationService : IRESTIntegrationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl;

        public RESTIntegrationService(string serviceUrl)
        {
            _httpClient = new HttpClient();
            _serviceUrl = serviceUrl;
        }

        public void Connect()
        {
            // REST services usually don't need a persistent connection
            Console.WriteLine("Connecting to REST service...");
        }

        public void Disconnect()
        {
            // REST services usually don't need a disconnect step
            Console.WriteLine("Disconnecting from REST service...");
        }

        public async Task SendDataAsync(object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_serviceUrl, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<object> ReceiveDataAsync()
        {
            var response = await _httpClient.GetAsync(_serviceUrl);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(responseData);
        }
    }

}
