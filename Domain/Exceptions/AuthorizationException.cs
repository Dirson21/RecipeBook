namespace Domain.Exceptions
{
    public class AuthorizationException : HttpStatusException
    {
        public AuthorizationException(string message) :
            base(461, message)
        {
        }
    }
}
