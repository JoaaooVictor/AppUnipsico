using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Models.DTOs;
using AppUnipsico.Models.Models.Usuarios;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        //public Task<IEnumerable<Usuario>> BuscaTodosProfessores();
        //public Task<IEnumerable<Usuario>> BuscaTodosAlunos();
        //public Task<IEnumerable<Usuario>> BuscaTodosPacientes();
        //public Task<TrataRetornoDTO> CriaUsuarioAsync(CriaUsuarioDTO userModel);
        //public Task<Usuario> BuscaUsuarioPorId(Guid usuarioId);
        //public Task<TrataRetornoDTO> LogarUsuarioAsync(RequisicaoLoginDTO userLoginDto);
        //public Task<RespostaLoginDTO> ValidaCredenciaisAsync(RequisicaoLoginDTO userLoginDto);
        public string GeraTokenJwt(Usuario usuario);
        //public Task<TrataRetornoDTO> BuscaUsuarioPorCpf(Usuario usuario);
    }
}