using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Silicon.Domain.Model.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Command
{
    /// <summary>
    /// Command that encapsulates the necessary properties for submitting a new command
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.Messaging.MessagingCommand" />
    /// <seealso cref="MediatR.IRequest{System.String}" />
    public class SubmitReceivedCommand : MessagingCommand, IRequest<string>, IValidatableObject
    {
        #region Fields
        #endregion

        #region Properties

        public override string Domain
        { get; set; }

        public string CommandMessage
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitReceivedCommand"/> class.
        /// </summary>
        public SubmitReceivedCommand()
            : base()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
