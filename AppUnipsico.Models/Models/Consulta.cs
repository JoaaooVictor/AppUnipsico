
using AppUnipsico.Models.Enums;
using AppUnipsico.Models.Models.Usuarios;

namespace AppUnipsico.Models.Models
{
    public class Consulta
    {
        public Guid ConsultaId { get; set; }
        public TipoStatusConsulta ConsultaStatus { get; set; }
      
        public Guid PacienteId { get; set; }


        public DateTime? DataConsulta { get; set; }
        public Paciente Paciente { get; set; } = new Paciente();
    }
}
