using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ElementIoT.Silicon.Domain.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace ElementIoT.Silicon.DataProvider.AzureProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class DeviceDataProvider : SiliconAzureProvider
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the device table.
        /// </summary>
        /// <value>
        /// The device table.
        /// </value>
        protected CloudTable DeviceTable
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDataProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        public DeviceDataProvider(IConfiguration configService)
            : base(configService)
        {
            this.DeviceTable = this.TableClient.GetTableReference(this.ConfigService["AzureDataProvider:DeviceTableName"]);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the device.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Device> SaveDevice(Device entity)
        {
            try
            {
                // Create the CloudTable if it does not exist
                await this.DeviceTable.CreateIfNotExistsAsync();


            }
            catch (Exception ex)
            {
                throw;
            }


            return entity;
        }

        #endregion
    }
}
