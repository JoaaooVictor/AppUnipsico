namespace AppUnipsico.Models.DTOs
{
    public class RespostaLoginDTO
    {
        public string? Token { get; set; }
        public bool Logado { get; set; }
        public string Mensagem { get; set; }
    }
}
