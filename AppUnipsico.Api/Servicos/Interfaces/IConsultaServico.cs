using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IConsultaServico
    {
        public Task<RespostaAgendaConsultaDTO> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO);
    }
}
