using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Silicon.Service.Command;
using ElementIoT.Particle.Infrastructure.Api;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ElementIoT.Silicon.Repository.Query;

namespace ElementIoT.Silicon.Api.Gateway.Controllers.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Api.CommonController" />
    [Produces("application/json")]
    [Route("api/silicon/device")]
    [ApiController]
    public class DeviceController : CommonController
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the device repository.
        /// </summary>
        /// <value>
        /// The device service.
        /// </value>
        protected IDeviceRepository DeviceRepository
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceController" /> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="deviceRepository">The device repository.</param>
        public DeviceController(
            IConfiguration configService,
            ILogPolicy logService,
            IErrorPolicy errorService,
            IDeviceRepository deviceRepository)
            : base(configService, logService, errorService)
        {
            this.DeviceRepository = deviceRepository;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Route("{id}")]
        // [Authorize]
        public async Task<IActionResult> GetDevice(string id)
        {
            try
            {
                // Check the model state and validate the integrity of the data
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var entity = await this.DeviceRepository.GetDeviceByID(id);

                    return Json(entity);
                }

                return HandleBadRequest();
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        #endregion
    }
}