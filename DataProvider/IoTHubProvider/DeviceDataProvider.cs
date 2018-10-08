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

namespace ElementIoT.Silicon.DataProvider.IoTHubProvider
{
    public class DeviceDataProvider : SiliconIoTHubProvider, IDeviceDataProvider
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
            using (RegistryManager registryManager = RegistryManager.CreateFromConnectionString(this.ConnectionString))
            {
                bool isProvisioned = false;
                int attempts = 0;

                // Attept to provision the device up to 'ProvisioningAttepts' times
                while (!isProvisioned && ++attempts <= this.ProvisioningAttempts)
                {
                    try
                    {
                        Device device;

                        entity.Identity.GenerateHubKey();
                        device = await registryManager.AddDeviceAsync(new Device(entity.Identity.HubID));

                        // Set the provisioned device identity's properties from the IoT Hub into the domain Device
                        entity.Identity.IsConnected = device.ConnectionState == DeviceConnectionState.Connected;
                        entity.Identity.IsEnabled = device.Status == DeviceStatus.Enabled;

                        entity.Identity.Authentication = new DomainEntity.DeviceAuthentication
                        {
                            PrimaryKey = device.Authentication.SymmetricKey.PrimaryKey,
                            SecondaryKey = device.Authentication.SymmetricKey.SecondaryKey
                        };

                        isProvisioned = true;
                    }
                    catch (DeviceAlreadyExistsException ex)
                    {
                        var log = new LogEntry(InfoMessages.IoTHubProvider_DeviceHubIdAlreadyExists)
                        {
                            Arguments = new { entity.Identity.HubID },
                            Error = ex
                        };

                        this.LogService.LogInfo(log);
                    }
                }

                // If the proviosioning failed, throw an exception with the error.
                if (!isProvisioned)
                {
                    throw new IoTException(ErrorMessages.IoTHubProvider_ProvisionDeviceIdentityFailed);
                }
            }

            return entity;
        }

        #endregion

    }
}
