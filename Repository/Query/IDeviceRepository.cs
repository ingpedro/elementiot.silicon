using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Read;

namespace ElementIoT.Silicon.Repository.Query
{
    public interface IDeviceRepository
    {
        Task<DeviceReadModel> GetDeviceByID(string id);
    }
}