namespace AppUnipsico.Api.Models
{
    public class UsuarioModel
    {
        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
        public DateTime UsuarioDataNascimento { get; set; }
        public string UsuarioCpf { get; set; } = string.Empty;
        public string UsuarioSenha { get; set; } = string.Empty;
        public string UsuarioEmail { get; set; } = string.Empty;
        public bool UsuarioAtivo { get; set; }
        public DateTime UsuarioDataRegistro { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuarioModel TipoUsuario { get; set; } = new TipoUsuarioModel();
    }
}
