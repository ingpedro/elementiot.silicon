using ElementIoT.Silicon.Domain.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using IoTHubProvider = ElementIoT.Silicon.DataProvider.IoTHubProvider;
using SqlProvider = ElementIoT.Silicon.DataProvider.SqlProvider;
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

        IoTHubProvider.IDeviceDataProvider IoTDeviceProvider
        { get; }

        SqlProvider.IDeviceDataProvider SqlDeviceProvider
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
        /// <param name="deviceProvider">The device provider.</param>
        public DeviceRepository(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService,
                                IoTHubProvider.IDeviceDataProvider deviceIdentityProvider, SqlProvider.IDeviceDataProvider deviceProvider)
            : base(configService, errorService, logService)
        {
            this.IoTDeviceProvider = deviceIdentityProvider;
            this.SqlDeviceProvider = deviceProvider;
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

            return entity;
        }

        #endregion
    }
}
