

namespace Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int CountPerson { get; set; }

        List<IngridientDto> Ingridients { get; set; }
        List<TagDto> Tags { get; set; }
        List<CookingStepDto> CookingSteps { get; set; }

    }
}
