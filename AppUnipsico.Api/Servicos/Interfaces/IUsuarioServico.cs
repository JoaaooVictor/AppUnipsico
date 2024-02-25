using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        public Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes();
        public Task<UsuarioModel> CriaUsuarioAsync(CriaUsuarioDTO userModel);
        public Task<UsuarioModel> BuscaUsuarioPorId(Guid usuarioId);
        public Task<string> LogarUsuarioAsync(RequisicaoLoginDTO userLoginDto);
        public Task<RespostaLoginDTO> ValidaCredenciaisAsync(RequisicaoLoginDTO userLoginDto);
        public string GeraTokenJwt(UsuarioModel usuario);
    }
}