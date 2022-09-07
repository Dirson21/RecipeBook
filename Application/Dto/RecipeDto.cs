


namespace Application.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int CountPerson { get; set; }

        public int CountLike { get; set; } = 0;

        public int CountFavorite { get; set; } = 0;

        public bool IsFavorite { get; set; } = false;
        public bool IsLike { get; set; } = false;

        public List<IngredientHeaderDto> IngredientHeaders { get; set; } = new List<IngredientHeaderDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public List<CookingStepDto> CookingSteps { get; set; } = new List<CookingStepDto>();

        public UserAccountDto UserAccount { get; set; } = new UserAccountDto();

       

    }
}
