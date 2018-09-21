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

namespace ElementIoT.Silicon.Api.Gateway.Controllers.Command
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
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(202)]
        [Route("")]
        // [Authorize]
        public async Task<IActionResult> ProvisionDevice([FromBody]ProvisionDeviceCommand command)
        {
            try
            {
                // Check the model state and validate the integrity of the data
                if (command != null && ModelState.IsValid)
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