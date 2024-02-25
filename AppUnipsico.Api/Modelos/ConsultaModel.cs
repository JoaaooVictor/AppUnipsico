using AppUnipsico.Api.Models.Enums;

namespace AppUnipsico.Api.Models
{
    public class ConsultaModel
    {
        public Guid ConsultaId { get; set; }
        public StatusConsulta ConsultaStatus { get; set; }
        public DateTime DataConsulta { get; set; }
        public Guid PacienteId { get; set; }
        public PacienteModel Paciente { get; set; } = new PacienteModel();

    }
}
