using ElementIoT.Particle.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    /// <summary>
    /// Defines a type that represents the authentication information that a device uses to connect to the IoT platform and IoT Hub
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.ValueObject" />
    public class DeviceAuthentication: ValueObject
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the type of the authentication.
        /// </summary>
        /// <value>
        /// The type of the authentication.
        /// </value>
        public DeviceAuthenticationType AuthenticationType
        { get; set; }

        /// <summary>
        /// Gets or sets the X509 client certificate primary thumbprint.
        /// </summary>
        /// <value>
        /// The primary thumbprint.
        /// </value>
        public string PrimaryThumbprint
        { get; set; }

        /// <summary>
        /// Gets or sets the X509 client certificate secondary thumbprint.
        /// </summary>
        /// <value>
        /// The secondary thumbprint.
        /// </value>
        public string SecondaryThumbprint
        { get; set; }

        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        public string PrimaryKey
        { get; set; }

        /// <summary>
        /// Gets or sets the secondary key.
        /// </summary>
        /// <value>
        /// The secondary key.
        /// </value>
        public string SecondaryKey
        { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}