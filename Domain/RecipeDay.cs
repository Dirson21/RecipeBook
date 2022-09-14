using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipeDay
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        
        public Recipe Recipe { get; set; }

        public DateTime Date { get; private set; }

        public RecipeDay()
        {
            Date = DateTime.Now;
            Recipe = new Recipe();
        }

    }
}
