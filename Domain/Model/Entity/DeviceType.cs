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

        public string ID
        { get; set; }

        public string Name
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
