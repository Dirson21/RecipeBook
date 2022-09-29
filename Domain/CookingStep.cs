﻿namespace Domain
{
    public class CookingStep
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }

        public Recipe Recipe { get; set; }
    }
}
