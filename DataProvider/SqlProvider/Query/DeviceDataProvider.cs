using Dapper;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Read;
using ElementIoT.Silicon.Resource.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.SqlProvider.Query
{
    public class DeviceDataProvider : SiliconSQLProvider, IDeviceQueryDataProvider
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDataProvider" /> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        public DeviceDataProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService)
            : base(configService, errorService, logService)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the device by its identifier.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        /// <exception cref="IoTException"></exception>
        public async Task<DeviceReadModel> GetDevice(string id)
        {
            try
            {
                DeviceReadModel entity;

                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(ErrorMessages.Validation_DeviceIDMissing, "Device ID");

                var parameters = new DynamicParameters();

                parameters.Add("@DeviceID", id, DbType.String, ParameterDirection.Input);

                var procedure = "[Device].[USPGetDevice]";

                CommandDefinition command = new CommandDefinition(procedure, parameters: parameters, commandType: CommandType.StoredProcedure);

                entity = await this.QuerySingleAsync<DeviceReadModel>(command);

                return entity;
            }
            catch (Exception ex)
            {
                throw new IoTException(ErrorMessages.GetDevice_SqlProviderUnexpected, ex, ErrorReasonTypeEnum.DataProvider);
            }
        }
    }

    #endregion


}

