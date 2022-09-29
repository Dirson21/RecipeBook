namespace Domain
{
    public class RecipeFavorite
    {
        public int RecipeId { get; set; }
        public Guid UserAccountId { get; set; }

        public DateTime Date { get; set; }

        public Recipe Recipe { get; set; }

        public UserAccount UserAccount { get; set; }

    }
}
