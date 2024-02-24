using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Web.Services.InterfacesWeb
{
    public interface IUsuarioServicoWeb
    {
        public Task<RespostaLoginDTO> Logar(RequisicaoLoginDTO requestLoginDto);
    }
}
