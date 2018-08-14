using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Domain.Exceptions
{
    public class ProviderDomainException : Exception
    {
        public ProviderDomainException()
        { }

        public ProviderDomainException(string message)
            : base(message)
        { }

        public ProviderDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
