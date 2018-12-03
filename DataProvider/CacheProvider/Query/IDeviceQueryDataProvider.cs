using ElementIoT.Silicon.Domain.Model.Entity;
using ElementIoT.Silicon.Domain.Model.Read;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.CacheProvider.Query
{
    public interface IDeviceQueryDataProvider
    {
        Task<DeviceReadModel> GetDevice(string entityId);
    }
}
