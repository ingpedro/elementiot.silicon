using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Silicon.Domain.Model.Event;
using ElementIoT.Silicon.Service.Command;
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
        ElementIoT.Particle.Infrastructure.Model.Handling.IEventHandler<CommandReceivedEvent>,
        INotificationHandler<CommandReceivedEvent>
    {
        #region Properties

        public ICommandService CommandService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEventHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public CommandEventHandler(ILogPolicy logService, IErrorPolicy errorService,
                                   ICommandService commandService)
            : this(logService, errorService)
        {
            this.CommandService = commandService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task Handle(CommandReceivedEvent notification, CancellationToken cancellationToken)
        {
            await this.Handle(notification);
        }
        
        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="command">The command.</param>
        public async Task Handle(CommandReceivedEvent notification)
        {
            try
            {
                SubmitReceivedCommand command = new SubmitReceivedCommand
                {
                    Domain = notification.Command.Domain,
                    CommandMessage = notification.Command.ToString()
                };

                await this.CommandService.ProcessReceivedCommand(command);
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



/*
 public int MyProperty { get; private set ;}

[ContractInvariantMethod]
private void ObjectInvariant ()
{
  Contract.Invariant ( this.MyProperty >= 0 );
}
     */
