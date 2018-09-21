using ElementIoT.Silicon.Domain.Model.Read;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Repository.Query
{
    public class DeviceRepository : IDeviceRepository
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors        

        #endregion

        #region Methods

        public async Task<DeviceReadModel> GetDeviceByID(string id)
        {
            DeviceReadModel entity = new DeviceReadModel
            {
                ID = "RFID-001",
                Name = "RFID Sensor Kitchen",
                IsMaster = false,
                DeviceType = new DeviceTypeReadModel
                {
                    ID = "RFID-TYPE",
                    Name = "RFID Sensor"
                },
                GeoLocation = new GeoLocationReadModel
                {
                    Latitude = 47.677064m,
                    Longitude = -122.131309m,
                    Address = "8383 158th Ave NE, Redmond, WA 98052"
                }
            };

            string json = JsonConvert.SerializeObject(entity, Formatting.Indented);

            System.Diagnostics.Debug.WriteLine("---------------------------------------");
            System.Diagnostics.Debug.WriteLine("REPOSITORY: Getting the entity using the repository.");
            System.Diagnostics.Debug.WriteLine(json);
            System.Diagnostics.Debug.WriteLine("---------------------------------------");

            return await Task.FromResult(entity);
        }

        #endregion
    }
}
