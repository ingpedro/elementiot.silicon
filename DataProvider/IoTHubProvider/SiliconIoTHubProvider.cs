using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Resource.Messages;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using System;

namespace ElementIoT.Silicon.DataProvider.IoTHubProvider
{
    public class SiliconIoTHubProvider
    {
        #region Fields

        private const string IOTHUB_CONNECTION_KEY = "IoTHub:ConnectionString";

        private const string PROVITIONING_ATTEPTS = "IoTHubProvider:ProvisioningAttepts";

        private const int defaultProvisioningAttempts = 3;

        #endregion

        #region Properties

        protected IConfiguration ConfigService
        { get; }

        protected IErrorPolicy ErrorService
        { get; }

        protected ILogPolicy LogService
        { get; }

        protected string ConnectionString
        { get; }

        protected int ProvisioningAttempts
        { get;  }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="SiliconIoTHubProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        /// <exception cref="IoTException"></exception>
        public SiliconIoTHubProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService)
        {
            this.ConfigService = configService;
            this.ErrorService = errorService;
            this.LogService = logService;

            //set connection string
            var iotHubKey = ConfigService[IOTHUB_CONNECTION_KEY];
            if (!string.IsNullOrWhiteSpace(iotHubKey))
            {
                this.ConnectionString = ConfigService[iotHubKey];
            }
            else
            {
                throw new IoTException(ErrorMessages.DataProvider_ConnectionStringKeyMissing, ErrorReasonTypeEnum.Configuration);
            }

            this.ProvisioningAttempts = this.ConfigService.GetValue<int>(PROVITIONING_ATTEPTS, defaultProvisioningAttempts);
        }

        #endregion

        #region Methods
        #endregion
    }
}
