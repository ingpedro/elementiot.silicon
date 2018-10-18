using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using DomainEntity = ElementIoT.Silicon.Domain.Model.Entity;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Common.Exceptions;
using ElementIoT.Silicon.Resource.Messages;

namespace ElementIoT.Silicon.DataProvider.IoTHubProvider.Command
{
    public class DeviceDataProvider : SiliconIoTHubProvider, IDeviceCommandDataProvider
    {
        #region Fields        
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDataProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        public DeviceDataProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService)
            : base(configService, errorService, logService)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Provisions the device identity int the IoT Hub.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The domain device</returns>
        /// <exception cref="IoTException"></exception>
        public async Task<DomainEntity.Device> ProvisionDevice(DomainEntity.Device entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(ErrorMessages.Validation_DeviceEntityMissing, "Device");

                if (entity.Identity == null)
                    throw new ArgumentNullException(ErrorMessages.Validation_DeviceIdentityMissing, "Device Identity");

                using (RegistryManager registryManager = RegistryManager.CreateFromConnectionString(this.ConnectionString))
                {
                    Device device;

                    try
                    {
                        entity.Identity.GenerateHubKey();

                        device = await registryManager.AddDeviceAsync(new Device(entity.Identity.HubID));
                    }
                    catch (DeviceAlreadyExistsException)
                    {
                        device = await registryManager.GetDeviceAsync(entity.Identity.HubID);
                    }

                    // Set the provisioned device identity's properties from the IoT Hub into the domain Device
                    entity.Identity.IsConnected = device.ConnectionState == DeviceConnectionState.Connected;
                    entity.Identity.IsEnabled = device.Status == DeviceStatus.Enabled;

                    entity.Identity.Authentication = new DomainEntity.DeviceAuthentication
                    {
                        PrimaryKey = device.Authentication.SymmetricKey.PrimaryKey,
                        SecondaryKey = device.Authentication.SymmetricKey.SecondaryKey
                    };
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new IoTException(ErrorMessages.ProvisionDevice_IoTProviderUnexpected, ex, ErrorReasonTypeEnum.DataProvider);
            }
        }

        #endregion

    }
}
