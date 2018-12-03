using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Silicon.Domain.Model.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Event
{
    public class ProvisionDeviceEvent : MessagingEvent, INotification
    {
        #region Fields
        #endregion

        #region Properties

        public MessagingCommand Command
        { get; }

        public Device Entity
        { get; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionDeviceEvent" /> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        public ProvisionDeviceEvent(MessagingCommand command, Device entity)
            : base()
        {
            this.Command = command;
            this.Entity = entity;
        }

        #endregion

        #region Methods
        #endregion
    }
}
