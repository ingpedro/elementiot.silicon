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
    public class DeviceReadModel : ReadEntity<Guid>
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value that the application and customer will use to identify the device.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [JsonProperty("deviceId")]
        public string DeviceID
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
        /// Gets or sets the description of the device.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description
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
        /// Gets or sets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isRoot")]
        public bool IsRoot
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isEnabled")]
        public bool IsEnabled
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceReadModel"/> class.
        /// </summary>
        public DeviceReadModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceReadModel"/> class.
        /// </summary>
        /// <remarks>
        /// Stored Procedures:
        /// - [Device].[USPGetDevice]
        /// </remarks>
        /// <param name="Key">The key.</param>
        /// <param name="DeviceId">The device identifier.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Description">The description.</param>
        /// <param name="DeviceTypeKey">The device type key.</param>
        /// <param name="IsRoot">if set to <c>true</c> [is root].</param>
        /// <param name="IsEnabled">if set to <c>true</c> [is enabled].</param>
        /// <param name="CreatedBy">The created by.</param>
        /// <param name="CreatedDate">The created date.</param>
        /// <param name="UpdatedBy">The updated by.</param>
        /// <param name="UpdatedDate">The updated date.</param>
        public DeviceReadModel(
            Guid Key, string DeviceId, string Name, string Description,
            Guid DeviceTypeKey,
            bool IsRoot, bool IsEnabled,
            string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate)
        {
            this.Key = Key;
            this.DeviceID = DeviceId;
            this.Name = Name;
            this.Description = Description;

            this.IsRoot = IsRoot;
            this.IsEnabled = IsEnabled;

            this.DeviceType = new DeviceTypeReadModel()
            {
                Key = DeviceTypeKey
            };

            this.CreatedBy = CreatedBy;
            this.CreatedDate = CreatedDate;
            this.UpdatedBy = UpdatedBy;
            this.UpdateDate = UpdatedDate;
        }

        #endregion

        #region Methods
        #endregion

    }
}
