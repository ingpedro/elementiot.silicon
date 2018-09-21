using ElementIoT.Silicon.Domain.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Repository.Command
{
    public class DeviceRepository : IDeviceRepository
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constuctors
        #endregion

        #region Mehods

        /// <summary>
        /// Saves the device.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Device> SaveDevice(Device entity)
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.Indented);

            System.Diagnostics.Debug.WriteLine("---------------------------------------");
            System.Diagnostics.Debug.WriteLine("REPOSITORY: Saving the entity using the repository.");
            System.Diagnostics.Debug.WriteLine(json);
            System.Diagnostics.Debug.WriteLine("---------------------------------------");

            return await Task.FromResult(entity);
        }

        #endregion
    }
}
