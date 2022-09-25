using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AuthorizationException : HttpStatusException
    {
        public AuthorizationException(string message) :
            base(414, message)
        {
        }
    }
}
