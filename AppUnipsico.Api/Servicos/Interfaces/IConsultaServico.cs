using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IConsultaServico
    {
        public Task<TrataRetornoDTO> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO);
        public Task<TrataRetornoDTO> DesmarcarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO);
        public Task<TrataRetornoDTO> EditarConsulta(ConsultaModel consulta);
        public Task<IEnumerable<ConsultaModel>> ListarConsultasPorPaciente(Guid pacienteId);
        public Task<IEnumerable<ConsultaModel>> ListarConsultaPorMes(int ano, int mes);
    }
}
