using ElementIoT.Particle.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AggregateRoot" />
    public class Device: AggregateRoot
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value that the IoT Hub will use to identify the device in its registry.
        /// </summary>
        /// <value>
        /// The hub identifier.
        /// </value>
        public string HubID
        { get; set; }

        /// <summary>
        /// Gets or sets the value that the application and customer will use to identify the device.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public string DeviceID
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
        /// Gets or sets the description of the device.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
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
        /// Gets or sets a value indicating whether this instance is the root device.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master; otherwise, <c>false</c>.
        /// </value>
        public bool IsRoot
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the parent device.
        /// </summary>
        /// <value>
        /// The prent device.
        /// </value>
        public Device ParentDevice
        { get; set; }

        /// <summary>
        /// Gets or sets the child devices.
        /// </summary>
        /// <value>
        /// The child devices.
        /// </value>
        public ICollection<Device> ChildDevices
        { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
