using ElementIoT.Silicon.Domain.Model.Entity;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.DataProvider.AzureProvider.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAzure.Storage.Table.TableEntity" />
    public class DeviceTableEntity : TableEntity
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceTableEntity"/> class.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        public DeviceTableEntity(string partitionKey, string rowKey)
            :base(partitionKey, rowKey)
        {

        }

        #endregion

        #region Methods

        public static DeviceTableEntity FromDomain(Device entity)
        {
            DeviceTableEntity tableEntity = new DeviceTableEntity(entity.DeviceType.Name, entity.HubID);


            return tableEntity;
        }

        #endregion
    }
}
