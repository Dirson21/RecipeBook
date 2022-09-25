namespace Application.Dto
{
    public class ErrorResponse
    {
        public string Type { get; private set; }
        public string Message { get; private set; }

        public ErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;

        }
    }
}
