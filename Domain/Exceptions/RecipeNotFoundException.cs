namespace Domain.Exceptions
{
    public class RecipeNotFoundException : HttpStatusException
    {
        public RecipeNotFoundException(string message) : base(404, message)
        {
        }
    }
}
