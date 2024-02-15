using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnipsico.Models.DTOs
{
    public class CreateUserDto
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
