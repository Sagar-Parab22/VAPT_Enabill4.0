using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
namespace Enabill.IntegrationLayer
{

    public class WCFIntegrationService : IWCFIntegrationService
    {
        private readonly string _serviceUrl;
        private ICommunicationObject _client;

        public WCFIntegrationService(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public void Connect()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(_serviceUrl);
            _client = new ChannelFactory<ICommunicationObject>(binding, endpoint).CreateChannel();
            _client.Open();
            Console.WriteLine("Connecting to WCF service...");
        }

        public void Disconnect()
        {
            if (_client != null && _client.State == CommunicationState.Opened)
            {
                _client.Close();
                Console.WriteLine("Disconnecting from WCF service...");
            }
        }

        public async Task SendDataAsync(object data)
        {
            // Assuming there's a method named "SendData" on the WCF service
            await Task.Run(() => ((dynamic)_client).SendData(data));
        }

        public async Task<object> ReceiveDataAsync()
        {
            // Assuming there's a method named "ReceiveData" on the WCF service
            return await Task.Run(() => ((dynamic)_client).ReceiveData());
        }
    }

}
