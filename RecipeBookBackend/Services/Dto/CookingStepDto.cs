﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{

    public class CookingStepDto
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }


    }
}
