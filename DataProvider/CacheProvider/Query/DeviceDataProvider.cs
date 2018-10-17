using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElementIoT.Particle.Operational.Caching;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace ElementIoT.Silicon.DataProvider.CacheProvider.Query
{
    public class DeviceDataProvider : SiliconCacheProvider
    {
        #region Fields

        private string cacheScope;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the cache service.
        /// </summary>
        /// <value>
        /// The cache service.
        /// </value>
        public ICachePolicy CacheService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDataProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="cacheService">The cache service.</param>
        public DeviceDataProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService, ICachePolicy cacheService)
            : base(configService, errorService, logService)
        {
            this.CacheService = cacheService;

            this.cacheScope = this.GetType().ToString();

            // Create new scope where to save the entities from this provider
            this.CacheService.CreateScope(this.cacheScope);
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        public async Task<Device> GetDevice(string entityId)
        {
            return await Task.FromResult(this.CacheService.Get<Device>(this.cacheScope, entityId));
        }

        #endregion
    }
}
