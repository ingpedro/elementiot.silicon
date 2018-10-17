using ElementIoT.Silicon.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.CacheProvider.Command
{
    public interface IDeviceCommandDataProvider
    {
        Task<Device> SaveDevice(Device entity);
    }
}
