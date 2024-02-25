using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface ITipoUsuarioServico
    {
        public Task<TipoUsuarioModel> BuscaTipoUsuarioPorId(int id);
    }
}
