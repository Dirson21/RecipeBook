namespace Domain.Exceptions
{
    public class InvalidPasswordException : HttpStatusException
    {


        public InvalidPasswordException(string message) :
            base(462, message)
        {
        }

    }
}
