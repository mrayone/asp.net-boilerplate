using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Exceptions
{
    public class IdentidadeAcessoDomainException : Exception
    {
        public IdentidadeAcessoDomainException()
        {}

        public IdentidadeAcessoDomainException(string message) : base(message)
        {

        }
    }
}
