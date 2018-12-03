using ElementIoT.Particle.Infrastructure.Model;
using ElementIoT.Silicon.Domain.Model.Read;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    public class GeoLocation: ValueObject
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

        public GeoLocationReadModel ToReadModel()
        {
            return new GeoLocationReadModel
            {
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Address = this.Address
            };
        }

        #endregion
    }
}
