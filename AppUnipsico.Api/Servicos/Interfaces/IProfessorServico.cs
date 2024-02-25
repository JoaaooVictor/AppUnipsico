using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IProfessorServico
    {
        public Task<ProfessorModel> CriaProfessorAsync(UsuarioModel usuarioModel);
    }
}
