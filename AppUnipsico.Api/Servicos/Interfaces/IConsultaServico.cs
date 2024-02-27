using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Models.DTOs;
using AppUnipsico.Models.Models;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IConsultaServico
    {
        public Task<TrataRetornoDTO> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO);
        public Task<TrataRetornoDTO> DesmarcarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO);
        public Task<TrataRetornoDTO> EditarConsulta(Consulta consulta);
        public Task<IEnumerable<Consulta>> ListarConsultasPorPaciente(Guid pacienteId);
        public Task<IEnumerable<Consulta>> ListarConsultaPorMes(int ano, int mes);
        public Task LerEInserirConsultas();
    }
}
