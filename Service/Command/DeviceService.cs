using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using System;
using System.Threading.Tasks;
using CacheQProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Query;
using ElementIoT.Silicon.Domain.Model.Entity;
using System.Collections.Generic;
using ElementIoT.Silicon.Resource.Messages;
using ElementIoT.Particle.Operational.Error;

namespace ElementIoT.Silicon.Service.Command
{
    /// <summary>
    /// Application service responsible for validating and processing Device actions.
    /// </summary>
    /// <seealso cref="CommonService" />
    /// <seealso cref="IDeviceService" />
    public class DeviceService : CommonService, IDeviceService
    {
        #region Fields
        #endregion

        #region Properties

        protected CacheQProvider.IDeviceQueryDataProvider CacheQueryProvider
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService" /> class.
        /// </summary>
        /// <param name="commandBus">The command bus.</param>
        /// <param name="cacheQueryProvider">The cache query provider.</param>
        public DeviceService(ICommandBus commandBus,
                             CacheQProvider.IDeviceQueryDataProvider cacheQueryProvider)
            : base(commandBus)
        {
            this.CacheQueryProvider = cacheQueryProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Provisions a new device in the platform.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task ProvisionDevice(ProvisionDeviceCommand command)
        {
            // Do some business validation here. Make calls to the Query side to get additional domain info.           

            this.ProvisionDeviceValidate(command);

            // Send the command to the command bus
            await this.CommandBus.Send(command);
        }


        public void ProvisionDeviceValidate(ProvisionDeviceCommand command)
        {
            List<string> commandErrors = new List<string>();

            Device existingDevice = this.CacheQueryProvider.GetDevice(command.DeviceID).Result;

            if (existingDevice != null)
            {
                commandErrors.Add(ErrorMessages.ProvisionDevice_DeviceExists);
            }

            if (commandErrors.Count > 0)
            {
                throw new IoTException(ErrorMessages.Service_ValidationFailed, ErrorReasonTypeEnum.Validation, commandErrors.ToArray());
            }
        }

        #endregion
    }
}
