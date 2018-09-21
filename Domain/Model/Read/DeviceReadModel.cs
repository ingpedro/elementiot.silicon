using ElementIoT.Particle.Infrastructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Read
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.ReadEntity{System.Guid}" />
    public class DeviceReadModel: ReadEntity<Guid>
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
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>
        /// The type of the device.
        /// </value>
        [JsonProperty("deviceType")]
        public DeviceTypeReadModel DeviceType
        { get; set; }

        /// <summary>
        /// Gets or sets the geo location.
        /// </summary>
        /// <value>
        /// The geo location.
        /// </value>
        [JsonProperty("geoLocation")]
        public GeoLocationReadModel GeoLocation
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

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion

    }
}
