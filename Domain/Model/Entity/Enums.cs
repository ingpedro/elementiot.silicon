
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Silicon.Domain.Model.Entity
{
    /// <summary>
    /// defines a type that represents the authentication type a device uses.
    /// </summary>
    public enum DeviceAuthenticationType
    {    
        /// <summary>
        /// Shared Access Key
        /// </summary>
        Sas = 0,
    
        /// <summary>
        /// Self-signed certificate
        /// </summary>
        SelfSigned = 1,

        /// <summary>
        /// The certificate authority
        /// </summary>
        CertificateAuthority = 2,

        /// <summary>
        /// No authentication
        /// </summary>
        None = 3
    }
}
