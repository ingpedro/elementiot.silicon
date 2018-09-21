using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Silicon.Domain.Model.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Event
{
    public class ProvisionDeviceEvent: MessagingEvent, INotification
    {
        #region Fields
        #endregion

        #region Properties

        public Device Device
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionDeviceEvent"/> class.
        /// </summary>
        public ProvisionDeviceEvent()
            :base()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new instance of <see cref="ProvisionDeviceEvent"/> from the given entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static ProvisionDeviceEvent FromEntity(Device entity)
        {
            return new ProvisionDeviceEvent()
            {
                Device = entity
            };
        }

        #endregion
    }
}
