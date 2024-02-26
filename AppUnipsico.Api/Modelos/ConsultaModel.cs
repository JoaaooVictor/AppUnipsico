using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Models.Enums;

namespace AppUnipsico.Api.Models
{
    public class ConsultaModel
    {
        public Guid ConsultaId { get; set; }
        public StatusConsulta ConsultaStatus { get; set; }
        public Guid DataConsultaId { get; set; }
        public DataConsultaModel DataConsulta { get; set; }
        public Guid PacienteId { get; set; }
        public PacienteModel Paciente { get; set; } = new PacienteModel();
    }
}
