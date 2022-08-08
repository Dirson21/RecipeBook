using RecipeBookBackend.Domain;

namespace RecipeBookBackend.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int CountPerson { get; set; }
        List<Ingridient> Ingridients { get; set; }

    }
}
