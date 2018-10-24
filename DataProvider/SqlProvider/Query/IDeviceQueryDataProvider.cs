using ElementIoT.Silicon.Domain.Model.Read;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.SqlProvider.Query
{
    public interface IDeviceQueryDataProvider
    {
        Task<DeviceReadModel> GetDevice(string id);
    }
}
