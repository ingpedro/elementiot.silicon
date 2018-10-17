using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using Microsoft.Extensions.Configuration;
using System;

namespace ElementIoT.Silicon.DataProvider.CacheProvider
{
    public class SiliconCacheProvider
    {
        #region Fields
        #endregion

        #region Properties

        protected IConfiguration ConfigService
        { get; }

        protected IErrorPolicy ErrorService
        { get; }

        protected ILogPolicy LogService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SiliconCacheProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        public SiliconCacheProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService )
        {
            this.ConfigService = configService;
            this.ErrorService = errorService;
            this.LogService = logService;
        }

        #endregion

        #region Methods      


        #endregion


    }
}
