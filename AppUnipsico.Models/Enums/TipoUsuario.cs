using System.ComponentModel.DataAnnotations;

namespace AppUnipsico.Models.Enums
{
    public enum TipoUsuario
    {
        [Display(Name = "Nenhum")]
        Nenhuma = 0,
        [Display(Name = "Aluno")]
        Aluno = 1,
        [Display(Name = "Professor")]
        Professor = 2,
        [Display(Name = "Paciente")]
        Paciente = 3
    }
}
