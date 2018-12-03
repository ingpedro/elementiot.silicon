using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using ElementIoT.Particle.Infrastructure.Api;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Silicon.Service.Command;
using Microsoft.AspNetCore.Authorization;

namespace ElementIoT.Silicon.Api.Gateway.Controllers.Command
{
    /// <summary>
    /// Controller responsible for exposing the APIs that are used to manage Devices both in the Patform and in the IoT Hub
    /// </summary>
    /// <seealso cref="CommonController" />
    [Produces("application/json")]
    [Route("api/silicon/device")]
    [ApiController]
    public class DeviceController : CommonController
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the device service.
        /// </summary>
        /// <value>
        /// The device service.
        /// </value>
        protected IDeviceService DeviceService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceController" /> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="deviceService">The device service.</param>
        public DeviceController(
            IConfiguration configService,
            ILogPolicy logService,
            IErrorPolicy errorService,
            IDeviceService deviceService)
            : base(configService, logService, errorService)
        {
            this.DeviceService = deviceService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Provisions a new device in the platform.
        /// </summary>
        /// <param name="command">The provision device command.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(202)]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> ProvisionDevice([FromBody]ProvisionDeviceCommand command)
        {
            try
            {                
                // Check the model state and validate the integrity of the data
                if (ModelState.IsValid)
                {
                    await this.DeviceService.ProvisionDevice(command);

                    return Accepted();
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