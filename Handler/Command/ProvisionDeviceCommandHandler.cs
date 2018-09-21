using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Silicon.Domain.Model.Entity;
using ElementIoT.Particle.Infrastructure.Model.Handling;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Event;
using ElementIoT.Silicon.Repository.Command;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Particle.Operational.Error;

namespace ElementIoT.Silicon.Handler.Command
{
    public class ProvisionDeviceCommandHandler :
        CommandHandler<ProvisionDeviceCommand>,
        IRequestHandler<ProvisionDeviceCommand, string>
    {
        #region Properties        

        protected IDeviceRepository DeviceRepository
        { get; }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionDeviceCommandHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="eventBus">The event bus.</param>
        /// <param name="deviceRepository">The device repository.</param>
        public ProvisionDeviceCommandHandler(ILogPolicy logService, IErrorPolicy errorService, IEventBus eventBus, IDeviceRepository deviceRepository)
            :base(logService, errorService, eventBus)
        {
            this.DeviceRepository = deviceRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<string> Handle(ProvisionDeviceCommand request, CancellationToken cancellationToken)
        {
            await this.Handle(request);

            // Return the status of the handled operation.
            return await Task.FromResult(string.Empty);
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public override async Task Handle(ProvisionDeviceCommand command)
        {
            try
            {
                await base.Handle(command);

                // Create a new entity from the command.
                var entity = Map(command);

                // Persist the entity with the repository.
                await this.DeviceRepository.SaveDevice(entity);

                // Notify that the command was handled.
                await this.EventBus.Publish(ProvisionDeviceEvent.FromEntity(entity));
            }
            catch(Exception ex)
            {
                base.HandleError(ex, command);
            }
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Maps from command entity to corresponding repository entity.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private Device Map(ProvisionDeviceCommand command)
        {
            Device entity = new Device
            {
                ID = command.DeviceID,
                Name = command.DeviceName,
                DeviceType = new DeviceType { ID = command.DeviceTypeID},
                ParentDevice = new Device { ID = command.PrentDeviceID },
                IsMaster = command.IsMaster
            };

            return entity;
        }

        #endregion
    }
}
