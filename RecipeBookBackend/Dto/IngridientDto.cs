namespace RecipeBookBackend.Dto
{
    public class IngridientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }

        RecipeDto Recipe { get; set; }
    }
}
