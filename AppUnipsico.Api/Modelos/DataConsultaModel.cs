using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Modelos
{
    public class DataConsultaModel
    {
        public Guid DataConsultaId { get; set; }
        public DateTime DataConsulta { get; set; }
        public Guid? ConsultaId { get; set; }
        public virtual ConsultaModel? Consulta { get; set; }
    }
}
