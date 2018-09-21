using ElementIoT.Particle.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    public class Device: AggregateRoot
    {
        #region Fields

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>
        /// The type of the device.
        /// </value>
        public DeviceType DeviceType
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is master.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master; otherwise, <c>false</c>.
        /// </value>
        public bool IsMaster
        { get; set; }


        /// <summary>
        /// Gets or sets the prent device.
        /// </summary>
        /// <value>
        /// The prent device.
        /// </value>
        public Device ParentDevice
        { get; set; }

        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
