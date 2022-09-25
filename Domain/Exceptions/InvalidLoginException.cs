namespace Domain.Exceptions
{
    public class InvalidLoginException : HttpStatusException
    {
        public InvalidLoginException(string message) :
            base(460, message)
        {

        }
    }
}
