using System;
using System.Collections.Generic;
using System.Text;
using ElementIoT.Particle.Infrastructure.Model;
using ElementIoT.Particle.Operational.Utility;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    /// <summary>
    /// Defines a type that represents a device identity from the IoT Hub
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.ValueObject" />
    public class DeviceIdentity: ValueObject
    {
        #region Fields
        #endregion

        #region Proprties

        /// <summary>
        /// Gets or sets the value that the IoT Hub will use to identify the device in its registry.
        /// </summary>
        /// <value>
        /// The hub identifier.
        /// </value>
        public string HubID
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected
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
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public ICollection<string> Tags
        { get; set; }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        /// <value>
        /// The authentication.
        /// </value>
        public DeviceAuthentication Authentication
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceIdentity"/> class.
        /// </summary>
        public DeviceIdentity()
            :base()
        {
            this.Tags = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates the IoT Hub key which is assigned to this instance.
        /// </summary>
        /// <returns>The generated key.</returns>
        public string GenerateHubKey()
        {
            this.HubID = KeyGenUtility.GenerateBase64Key();

            return this.HubID;
        }

        #endregion
    }
}
