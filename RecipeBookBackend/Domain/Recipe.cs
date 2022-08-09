﻿namespace  Domain
{

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int CountPerson { get; set; }

        public List<Ingridient> Ingridients { get; set; }
        public  List<Tag> Tags { get; set; }
        public List<CookingStep> CookingSteps { get; set; }


    }
}
