using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Entity;

namespace ElementIoT.Silicon.Repository.Command
{
    public interface IDeviceRepository
    {
        Task<Device> SaveDevice(Device entity);
    }
}