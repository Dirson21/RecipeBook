namespace Domain.Exceptions
{
    public class HttpStatusException : Exception
    {
        public int Status => _status;
        private readonly int _status;

        public HttpStatusException(int status, string message) : base(message)
        {
            _status = status;
        }
    }
}
