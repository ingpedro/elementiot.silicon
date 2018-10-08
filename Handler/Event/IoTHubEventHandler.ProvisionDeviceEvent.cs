using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Event;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Handler.Event
{
    public partial class IoTHubEventHandler :
        ElementIoT.Particle.Infrastructure.Model.Handling.EventHandler<ProvisionDeviceEvent>,
        INotificationHandler<ProvisionDeviceEvent>
    {
        #region Properties        

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubEventHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public IoTHubEventHandler(ILogPolicy logService, IErrorPolicy errorService)
            : base(logService, errorService)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task Handle(ProvisionDeviceEvent notification, CancellationToken cancellationToken)
        {
            await this.Handle(notification);
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="command">The command.</param>
        public override async Task Handle(ProvisionDeviceEvent notification)
        {
            try
            {
                await base.Handle(notification);

                

            }
            catch (Exception ex)
            {
                base.HandleError(ex, notification);
            }
        }

        #endregion

        #region Helper Functions

        #endregion
    }
}
