﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositoy
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();
        List<Recipe> GetAll(int start, int count);
        Recipe GetById(int id);
        Recipe GetByName(string name);
        Recipe Create  (Recipe recipe);
        Recipe Update (Recipe recipe);
        void Delete (Recipe recipe);
        void Like(Recipe recipe, UserAccount userAccount);
        void Favorite(Recipe recipe, UserAccount userAccount);

        int CountLike(Recipe recipe);

        int CountFavorite(Recipe recipe);

        public void RemoveLike(Recipe recipe, UserAccount userAccount);

        public void RemoveFavorite(Recipe recipe, UserAccount userAccount);

        public bool IsLike(Recipe recipe, UserAccount userAccount);

        public bool IsFavorite(Recipe recipe, UserAccount userAccount);



    }
}
