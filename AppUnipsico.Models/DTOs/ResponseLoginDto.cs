namespace AppUnipsico.Models.DTOs
{
    public class ResponseLoginDto
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
