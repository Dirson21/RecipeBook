﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}