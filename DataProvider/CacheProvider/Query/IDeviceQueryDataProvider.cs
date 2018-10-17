using ElementIoT.Silicon.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.CacheProvider.Query
{
    public interface IDeviceQueryDataProvider
    {
        Task<Device> GetDevice(string entityId);
    }
}
