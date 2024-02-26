namespace AppUnipsico.Api.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataRegistro { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuarioModel TipoUsuario { get; set; } = new TipoUsuarioModel();
    }
}
