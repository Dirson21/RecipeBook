namespace Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngridientHeaderId { get; set; }
        public IngredientHeader IngredientHeader { get; set; }

    }
}
