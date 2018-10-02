using ElementIoT.Particle.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace ElementIoT.Silicon.Domain.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.Entity" />
    public class DeviceType: DomainEntity
    {
        #region Fields    
        #endregion

        #region Properties

        public string DeviceTypeID
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

        // TODO: DEFINE: Add more properties for this type.

        /// <summary>
        /// Gets or sets the extended properties.
        /// </summary>
        /// <value>
        /// The extended properties.
        /// </value>
        public ICollection<ExtendedProperty> ExtendedProperties
        { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
