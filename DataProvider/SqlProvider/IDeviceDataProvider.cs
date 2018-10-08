using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Entity;

namespace ElementIoT.Silicon.DataProvider.SqlProvider
{
    public interface IDeviceDataProvider
    {
        Task<Device> ProvisionDevice(Device entity);
    }
}