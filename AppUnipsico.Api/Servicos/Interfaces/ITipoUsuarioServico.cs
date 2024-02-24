using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Services.Interfaces
{
    public interface ITipoUsuarioServico
    {
        public Task<TipoUsuarioModel> BuscaTipoUsuarioPorId(int id);
    }
}
