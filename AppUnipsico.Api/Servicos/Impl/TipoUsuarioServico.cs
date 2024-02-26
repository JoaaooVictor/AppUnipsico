using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class TipoUsuarioServico : ITipoUsuarioServico
    {
        private readonly AppDbContext _context;

        public TipoUsuarioServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoUsuarioModel> BuscaTipoUsuarioPorId(int id)
        {
            return await _context.TiposUsuarios.SingleOrDefaultAsync(x => x.TipoUsuarioId == id);
        }
    }
}
