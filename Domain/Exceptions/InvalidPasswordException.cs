using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPasswordException : HttpStatusException
    {


        public InvalidPasswordException(string message) :
            base(462, message)
        {
        }
       
    }
}
