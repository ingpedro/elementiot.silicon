using Dapper;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Entity;
using ElementIoT.Silicon.Resource.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.DataProvider.SqlProvider
{
    /// <summary>
    /// Data Provider resposible for handling the data actions for Devices using SQL.
    /// </summary>
    /// <seealso cref="ElementIoT.Silicon.DataProvider.SqlProvider.SiliconSQLProvider" />
    public class DeviceDataProvider : SiliconSQLProvider, IDeviceDataProvider
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
        /// Provisions a new device in the platform's database
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Device> ProvisionDevice(Device entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Identity == null)
                throw new ArgumentNullException(nameof(entity));

            var parameters = new DynamicParameters();

            if(!string.IsNullOrWhiteSpace(entity.Identity.HubID))
                parameters.Add("@HubID", entity.Identity.HubID, DbType.String, ParameterDirection.Input);
            else
                throw new ArgumentException(ErrorMessages.Validation_HubIDMissing, "Hub ID");

            if (!string.IsNullOrWhiteSpace(entity.DeviceID))
                parameters.Add("@DeviceID", entity.DeviceID, DbType.String, ParameterDirection.Input);
            else
                throw new ArgumentException(ErrorMessages.Validation_DeviceIDMissing, "Device ID");

            if (entity.DeviceType != null && entity.DeviceType.Key != default(Guid))
                parameters.Add("@DeviceTypeKey", entity.DeviceType.Key, DbType.Guid, ParameterDirection.Input);
            else
                throw new ArgumentException(ErrorMessages.Validation_DeviceTypeKeyMissing, "Device Type Key");

            parameters.Add("@Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsRoot", entity.IsRoot, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@IsEnabled", entity.IsEnabled, DbType.Boolean, ParameterDirection.Input);

            parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String, ParameterDirection.Input);

            var procedure = "[Device].[USPCreateDevice]";

            CommandDefinition command = new CommandDefinition(procedure, parameters: parameters, commandType: CommandType.StoredProcedure);

            await this.ExecuteAsync(command);

            return entity;
        }

        #endregion
    }
}
