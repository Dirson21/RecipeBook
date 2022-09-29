namespace Domain
{
    public class IngredientHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


    }
}
