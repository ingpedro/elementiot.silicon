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
    public class DeviceTypeReadModel: ReadEntity<Guid>
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
