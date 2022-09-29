namespace Domain.Exceptions
{
    public class UserNotFoundException : HttpStatusException
    {
        public UserNotFoundException(string message) : base(404, message)
        {
        }
    }
}
