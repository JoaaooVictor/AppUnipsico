using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Services.Interfaces
{
    public interface IConsultaServico
    {
        public Task<bool> AgendaConsulta(DateTime dateConsult, Guid ConsultId);
    }
}
