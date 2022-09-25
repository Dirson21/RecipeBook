using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLoginException: HttpStatusException
    {
        public InvalidLoginException(string message):
            base(410 ,message)
        {

        }
    }
}
