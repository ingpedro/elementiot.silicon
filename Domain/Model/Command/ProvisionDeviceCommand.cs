using ElementIoT.Particle.Infrastructure.Model.Messaging;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Command
{
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
        [JsonProperty("deviceId")]
        public string DeviceID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        [Required]
        [JsonProperty("deviceName")]
        public string DeviceName
        { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>
        /// The type of the device.
        /// </value>
        [Required]
        [JsonProperty("deviceTypeId")]
        public string DeviceTypeID
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is master.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isMaster")]
        public bool IsMaster
        { get; set; }

        /// <summary>
        /// Gets or sets the prent device identifier.
        /// </summary>
        /// <value>
        /// The prent device identifier.
        /// </value>
        [JsonProperty("prentDeviceId")]
        public string PrentDeviceID
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
