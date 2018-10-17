using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Entity;

namespace ElementIoT.Silicon.DataProvider.IoTHubProvider.Command
{
    public interface IDeviceCommandDataProvider
    {
        Task<Device> ProvisionDevice(Device entity);
    }
}