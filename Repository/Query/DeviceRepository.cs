using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Read;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using SqlQProvider = ElementIoT.Silicon.DataProvider.SqlProvider.Query;
using CacheQProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Query;
using ElementIoT.Silicon.Domain.Model.Entity;

namespace ElementIoT.Silicon.Repository.Query
{
    public class DeviceRepository : SiliconRepository, IDeviceRepository
    {
        #region Fields
        #endregion

        #region Properties

        protected SqlQProvider.IDeviceQueryDataProvider SqlQueryProvider
        { get; }

        public CacheQProvider.IDeviceQueryDataProvider CacheQueryProvider
        { get; }

        #endregion

        #region Constructors        

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRepository" /> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="sqlQueryProvider">The SQL query provider.</param>
        /// <param name="cacheQueryProvider">The cache query provider.</param>
        public DeviceRepository(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService,
                                SqlQProvider.IDeviceQueryDataProvider sqlQueryProvider,
                                CacheQProvider.IDeviceQueryDataProvider cacheQueryProvider)
            : base(configService, errorService, logService)
        {
            this.SqlQueryProvider = sqlQueryProvider;
            this.CacheQueryProvider = cacheQueryProvider;
        }

        #endregion

        #region Methods

        public async Task<DeviceReadModel> GetDeviceByID(string id)
        {
            DeviceReadModel readModel;

            Device device = await this.CacheQueryProvider.GetDevice(id);

            if (device != null)
            {
                readModel = device.ToReadModel();
            }
            else
            {
                readModel = await this.SqlQueryProvider.GetDevice(id);
            }

            return readModel;
        }

        #endregion
    }
}
