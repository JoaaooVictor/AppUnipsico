namespace AppUnipsico.Models.DTOs
{
    public class RespostaLoginDTO
    {
        public string UsuarioNome { get; set; }
        public string UsuarioCpf { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }
        public int TipoUsuarioId { get; set; }
        public DateTime UsuarioDataNascimento { get; set; }
    }
}
