namespace  Domain
{

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int CountPerson { get; set; }

        public Guid UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }

        public List<IngredientHeader> IngredientHeaders { get; set; }
        public  List<Tag> Tags { get; set; } = new List<Tag>();
        public List<CookingStep> CookingSteps { get; set; }

       



    }
}
