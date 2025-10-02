using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enabill.IntegrationLayer
{
    public interface IServiceIntegration
    {
        void Connect();
        void Disconnect();
        Task SendDataAsync(object data);
        Task<object> ReceiveDataAsync();
    }

    public interface IRESTIntegrationService : IServiceIntegration { }

    public interface ISoapIntegrationService : IServiceIntegration { }

    public interface IWCFIntegrationService : IServiceIntegration { }

    public interface IThirdPartyIntegrationService : IServiceIntegration { }

}
