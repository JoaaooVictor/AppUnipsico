using System.ComponentModel.DataAnnotations;

namespace AppUnipsico.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é requerido!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
