using AppUnipsico.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace AppUnipsico.Models.Models.Usuarios
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataRegistro { get; set; }


        public TipoUsuario TipoUsuario { get; set; }
    }
}
