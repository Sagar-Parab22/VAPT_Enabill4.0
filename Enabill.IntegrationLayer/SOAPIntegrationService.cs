using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.ServiceModel;
namespace Enabill.IntegrationLayer
{

    public class SOAPIntegrationService : ISoapIntegrationService
    {
        private readonly string _serviceUrl;
        private dynamic _client;

        public SOAPIntegrationService(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public void Connect()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(_serviceUrl);
            _client = new ChannelFactory<dynamic>(binding, endpoint).CreateChannel();
            Console.WriteLine("Connecting to SOAP service...");
        }

        public void Disconnect()
        {
            if (_client != null)
            {
                ((IClientChannel)_client).Close();
                Console.WriteLine("Disconnecting from SOAP service...");
            }
        }

        public async Task SendDataAsync(object data)
        {
            // Assuming there's a method named "SendData" on the SOAP service
            await Task.Run(() => _client.SendData(data));
        }

        public async Task<object> ReceiveDataAsync()
        {
            // Assuming there's a method named "ReceiveData" on the SOAP service
            return await Task.Run(() => _client.ReceiveData());
        }
    }

}
