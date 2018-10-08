using ElementIoT.Silicon.Domain.Model.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Service.Command
{
    public interface IDeviceService
    {
        /// <summary>
        /// Provisions a new device in the platform.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        Task ProvisionDevice(ProvisionDeviceCommand command);
    }
}
