namespace AppUnipsico.Models.DTOs
{
    public class RequisicaoAgendaConsultaDTO
    {
        public Guid RequisicaoPacienteId { get; set; }
        public DateTime RequisicaoDataConsulta { get; set; }
        public Guid RequisicaoConsultaId { get; set; }
    }
}
