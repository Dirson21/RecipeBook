using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OwnerException : HttpStatusException
    {
        public OwnerException(string message) : base(416, message)
        {
        }
    }
}
