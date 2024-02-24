using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnipsico.Models.DTOs
{
    public class CriaUsuarioDTO
    {
        public string UserName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
