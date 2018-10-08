using ElementIoT.Particle.Infrastructure.Model.Messaging;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Command
{
    /// <summary>
    /// Command that encapsulates the necessary properties for provisioning a device
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.Messaging.MessagingCommand" />
    /// <seealso cref="MediatR.IRequest{System.String}" />
    public class ProvisionDeviceCommand : MessagingCommand, IRequest<string>
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [JsonProperty("deviceId")]
        public string DeviceID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        [JsonProperty("deviceName")]
        public string DeviceName
        { get; set; }

        /// <summary>
        /// Gets or sets the description of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        [JsonProperty("deviceDescription")]
        public string DeviceDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>
        /// The type of the device.
        /// </value>
        [Required]
        [JsonProperty("deviceTypeKey")]
        public Guid DeviceTypeKey
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is master.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isRoot",DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool IsRoot
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isEnabled", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool IsEnabled
        { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionDeviceCommand"/> class.
        /// </summary>
        public ProvisionDeviceCommand() 
            : base()
        {

        }

        #endregion

        #region Methods
        #endregion
    }
}
