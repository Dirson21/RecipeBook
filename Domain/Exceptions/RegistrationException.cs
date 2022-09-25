using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RegistrationException : HttpStatusException
    {
        public RegistrationException(string message) : base(415, message)
        {
        }
    }
}
