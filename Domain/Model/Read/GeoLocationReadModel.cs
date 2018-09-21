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
    public class GeoLocationReadModel: ReadEntity<Guid>
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        [JsonProperty("latitude")]
        public decimal Latitude
        { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        [JsonProperty("longitude")]
        public decimal Longitude
        { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [JsonProperty("address")]
        public string Address
        { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
