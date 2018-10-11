using ElementIoT.Particle.Infrastructure.Model.Messaging;
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
    public partial class CommandEventHandler :
        ElementIoT.Particle.Infrastructure.Model.Handling.EventHandler<CommandFailedEvent>,
        INotificationHandler<CommandFailedEvent>
    {
        #region Properties

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEventHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public CommandEventHandler(ILogPolicy logService, IErrorPolicy errorService)
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
        public async Task Handle(CommandFailedEvent notification, CancellationToken cancellationToken)
        {
            await this.Handle(notification);
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="command">The command.</param>
        public override async Task Handle(CommandFailedEvent notification)
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
