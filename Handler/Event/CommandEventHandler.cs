using ElementIoT.Particle.Infrastructure.Model.Handling;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Handler.Event
{
    public partial class CommandEventHandler:
        ElementIoT.Particle.Infrastructure.Model.Handling.EventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEventHandler" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public CommandEventHandler(ILogPolicy logService, IErrorPolicy errorService)
            : base(logService, errorService)
        {
        }
    }
}
