using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.DataProvider.AzureProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class SiliconAzureProvider
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        protected IConfiguration ConfigService
        { get; }

        /// <summary>
        /// Gets the storage account.
        /// </summary>
        /// <value>
        /// The storage account.
        /// </value>
        protected CloudStorageAccount StorageAccount
        { get; }

        protected CloudTableClient TableClient
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SiliconAzureProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        public SiliconAzureProvider(IConfiguration configService)
        {
            this.ConfigService = configService;

            StorageCredentials credentials = new StorageCredentials(this.ConfigService["AzureDataProvider:DeviceStorageName"],this.ConfigService["AzureDataProvider:DeviceStorageConnectionString"]);

            this.StorageAccount = new CloudStorageAccount(credentials, true);

            this.TableClient = this.StorageAccount.CreateCloudTableClient();


        }

        #endregion

        #region Methods

        #endregion
    }
}
