using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnipsico.Models.DTOs
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string UserCpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
    }
}
