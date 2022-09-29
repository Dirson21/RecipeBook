using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AddRecipeException : HttpStatusException
    {
        public AddRecipeException(string message) : base(467, message)
        {
        }
    }
}
