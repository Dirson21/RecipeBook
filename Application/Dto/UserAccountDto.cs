namespace Application.Dto
{
    public class UserAccountDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = "";

        public string Description { get; set; } = "";

        public string Name { get; set; } = "";

        public string NewPassword { get; set; } = "";

    }
}
