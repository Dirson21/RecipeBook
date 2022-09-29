namespace Application.Dto
{
    public class IngredientHeaderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RecipeId { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }
}
