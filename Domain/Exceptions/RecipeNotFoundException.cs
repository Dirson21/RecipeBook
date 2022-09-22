using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RecipeNotFoundException : HttpStatusException
    {
        public RecipeNotFoundException(string message) : base(412, message)
        {
        }
    }
}
