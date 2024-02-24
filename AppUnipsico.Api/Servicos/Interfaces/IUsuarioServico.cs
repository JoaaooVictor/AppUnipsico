using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Api.Services.Interfaces
{
    public interface IUsuarioServico
    {
        public Task<UsuarioModel> CriaUsuarioAsync(CriaUsuarioDTO userModel);
        public Task<UsuarioModel> LogaUsuarioAsync(RequisicaoLoginDTO userLoginDto);
        public Task<bool> ValidaCredenciaisAsync(RequisicaoLoginDTO userLoginDto);
        public Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes();
    }
}
