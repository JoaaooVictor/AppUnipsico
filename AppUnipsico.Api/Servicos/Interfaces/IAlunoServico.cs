using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IAlunoServico
    {
        public Task<AlunoModel> CriaAlunoAsync(UsuarioModel usuarioModel);
    }
}
