namespace Domain.Exceptions
{
    public class RegistrationException : HttpStatusException
    {
        public RegistrationException(string message) : base(465, message)
        {
        }
    }
}
