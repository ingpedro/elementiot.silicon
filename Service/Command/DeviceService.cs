using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using System;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Service.Command
{
    /// <summary>
    /// Application service responsible for validating and processing Device actions.
    /// </summary>
    /// <seealso cref="CommonService" />
    /// <seealso cref="IDeviceService" />
    public class DeviceService: CommonService, IDeviceService
    {
        #region Fields
        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        /// <param name="commandBus">The command bus.</param>
        public DeviceService(ICommandBus commandBus)
            :base(commandBus)
        {

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

            // Send the command to the command bus
            await this.CommandBus.Send(command);
        }

        #endregion
    }
}
