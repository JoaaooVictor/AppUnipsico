using System.ComponentModel.DataAnnotations;

namespace AppUnipsico.Models.Models.Usuarios
{
    public class Aluno : Usuario
    {
        [MaxLength(20)]
        public string Ra { get; set; }
        public Guid EstagioId { get; set; }
        public virtual IEnumerable<Estagio> Estagios { get; set; }
    }
}
