using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Services.Interfaces;

namespace AppUnipsico.Api.Services.Impl
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly AppDbContext _context;

        public ConsultaServico(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> AgendaConsulta(DateTime dateConsult, Guid ConsultId)
        {
            throw new NotImplementedException();
        }
    }
}
