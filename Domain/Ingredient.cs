namespace Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngredientHeaderId { get; set; }
        public IngredientHeader IngredientHeader { get; set; }

    }
}
