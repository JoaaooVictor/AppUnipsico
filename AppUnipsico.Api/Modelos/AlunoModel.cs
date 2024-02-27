using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Modelos
{
    public class AlunoModel : UsuarioModel
    {
        public string Ra { get; set; } = string.Empty;
        public Guid EstagioId { get; set; }
        public virtual IEnumerable<EstagioModel> Estagios { get; set; } = new List<EstagioModel>();
    }
}
