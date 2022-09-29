namespace Domain.Exceptions
{
    public class OwnerException : HttpStatusException
    {
        public OwnerException(string message) : base(463, message)
        {
        }
    }
}
