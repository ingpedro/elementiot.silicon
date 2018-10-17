using ElementIoT.Silicon.Domain.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using IoTCHubProvider = ElementIoT.Silicon.DataProvider.IoTHubProvider.Command;
using SqlCProvider = ElementIoT.Silicon.DataProvider.SqlProvider.Command;
using CacheCProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Command;
using CacheQProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Query;
using Microsoft.Extensions.Configuration;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;

namespace ElementIoT.Silicon.Repository.Command
{
    /// <summary>
    /// Data Repository responsible for coordinating data providers to fulfil Device actions
    /// </summary>
    /// <seealso cref="SiliconRepository" />
    /// <seealso cref="IDeviceRepository" />
    public class DeviceRepository : SiliconRepository, IDeviceRepository
    {
        #region Fields
        #endregion

        #region Properties

        IoTCHubProvider.IDeviceCommandDataProvider IoTDeviceProvider
        { get; }

        SqlCProvider.IDeviceCommandDataProvider SqlDeviceProvider
        { get; }

        CacheCProvider.IDeviceCommandDataProvider CacheCommandProvider
        { get; }

        CacheQProvider.IDeviceQueryDataProvider CacheQueryProvider
        { get; }

        #endregion

        #region Constuctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRepository"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="deviceIdentityProvider">The device identity provider.</param>
        /// <param name="sqlCommandProvider">The device provider.</param>
        public DeviceRepository(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService,
                                IoTCHubProvider.IDeviceCommandDataProvider deviceIdentityProvider, 
                                SqlCProvider.IDeviceCommandDataProvider sqlCommandProvider, 
                                CacheCProvider.IDeviceCommandDataProvider cacheCommandProvider,
                                CacheQProvider.IDeviceQueryDataProvider cacheQueryProvider)
            : base(configService, errorService, logService)
        {
            this.IoTDeviceProvider = deviceIdentityProvider;
            this.SqlDeviceProvider = sqlCommandProvider;
            this.CacheCommandProvider = cacheCommandProvider;
            this.CacheQueryProvider = cacheQueryProvider;
        }

        #endregion

        #region Mehods

        /// <summary>
        /// Saves the device.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Device> ProvisionDevice(Device entity)
        {
            // Provision the device in the IoT Hub, to generate the Hub ID and Auth properties
            entity = await this.IoTDeviceProvider.ProvisionDevice(entity);

            // Provision the device in the platform's database
            entity = await this.SqlDeviceProvider.ProvisionDevice(entity);

            // Provision the device in the platform's cache
            entity = await this.CacheCommandProvider.SaveDevice(entity);

            return entity;
        }

        #endregion
    }
}
