using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";

        public string Description { get; set; }
        public List<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}
