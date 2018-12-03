using ElementIoT.Particle.Infrastructure.Model.Handling;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Handler.Command
{
    public class SubmitReceivedCommandHandler :
        CommandHandler<SubmitReceivedCommand>,
        IRequestHandler<SubmitReceivedCommand, string>
    {
        #region Properties        

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionDeviceCommandHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="eventBus">The event bus.</param>
        /// <param name="deviceRepository">The device repository.</param>
        public SubmitReceivedCommandHandler(ILogPolicy logService, IErrorPolicy errorService, IEventBus eventBus)
            : base(logService, errorService, eventBus)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<string> Handle(SubmitReceivedCommand request, CancellationToken cancellationToken)
        {
            await this.Handle(request);

            // Return the status of the handled operation.
            return await Task.FromResult(string.Empty);
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public override async Task Handle(SubmitReceivedCommand command)
        {
            try
            {
                // Notify that the command was sent.
                // await this.EventBus.Publish(new CommandReceivedEvent(command));

                command.Handle();

                // Create a new entity from the command.
                var entity = Map(command);

                // Persist the entity with the repository.
                // await this.DeviceRepository.ProvisionDevice(entity);

                command.Handled();

                // Notify that the command was handled.
                // await this.EventBus.Publish(new ProvisionDeviceEvent(command, entity));
            }
            catch (Exception ex)
            {
                await this.EventBus.Publish(new CommandFailedEvent(command));

                throw base.HandleError(ex, command);
            }
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Maps from command entity to corresponding domain entity.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private object Map(SubmitReceivedCommand command)
        {
            return null;
        }

        #endregion
    }
}
