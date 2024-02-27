namespace AppUnipsico.Models.DTOs
{
    public class CriaUsuarioDTO
    {
        public string NomeUsuario { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
