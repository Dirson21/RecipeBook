namespace Domain.Repository
{
    public interface IUserRepository
    {
        public List<Recipe> GetUserRecipes(UserAccount user);

        public List<Recipe> GetUserFavoriteRecipes(UserAccount user);

        public int GetUserFavoriteRecipesCount(UserAccount user);

        public int GetUserLikesCount(UserAccount user);

    }
}
