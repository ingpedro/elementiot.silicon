using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Silicon.Domain.Model.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Silicon.Service.Command
{
    public interface ICommandService
    {
        Task ProcessReceivedCommand(SubmitReceivedCommand command);
    }
}
