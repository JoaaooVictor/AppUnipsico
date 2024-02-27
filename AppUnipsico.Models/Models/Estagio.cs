using AppUnipsico.Api.Modelos;
using AppUnipsico.Models.Models.Usuarios;

namespace AppUnipsico.Models.Models
{
    public class Estagio
    {
        public Guid EstagioId { get; set; }
        public DateTime EstagioDataRealizacao { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; } 
        public Guid InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; } 
    }
}
