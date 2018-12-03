using ElementIoT.Silicon.Domain.Model.Command;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using System;
using System.Threading.Tasks;
using CacheQProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Query;
using ElementIoT.Silicon.Domain.Model.Entity;
using System.Collections.Generic;
using ElementIoT.Silicon.Resource.Messages;
using ElementIoT.Particle.Operational.Error;

namespace ElementIoT.Silicon.Service.Command
{
    /// <summary>
    /// Application service responsible for managing operations for Commands 
    /// </summary>
    /// <seealso cref="ElementIoT.Silicon.Service.Command.CommonService" />
    class CommandService : CommonService, ICommandService
    {
        #region Fields
        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandService" /> class.
        /// </summary>
        /// <param name="commandBus">The command bus.</param>
        public CommandService(ICommandBus commandBus)
            : base(commandBus)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the received command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task ProcessReceivedCommand(SubmitReceivedCommand command)
        {
            // Do some business validation here. Make calls to the Query side to get additional domain info.           

            // Send the command to the command bus
            await this.CommandBus.Send(command);
        }

        #endregion
    }
}
