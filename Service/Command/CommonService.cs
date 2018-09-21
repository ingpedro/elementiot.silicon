using ElementIoT.Particle.Infrastructure.Model.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Service.Command
{
    public class CommonService
    {
        #region Fields
        #endregion

        #region Properties

        protected ICommandBus CommandBus { get; }

        #endregion

        #region Constructors

        public CommonService(ICommandBus commandBus)
        {
            this.CommandBus = commandBus;
        }

        #endregion

        #region Methods
        #endregion
    }
}
