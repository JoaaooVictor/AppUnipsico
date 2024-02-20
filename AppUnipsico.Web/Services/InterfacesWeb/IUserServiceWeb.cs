using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Web.Services.InterfacesWeb
{
    public interface IUserServiceWeb
    {
        public Task<ResponseLoginDto> Logar(RequestLoginDto requestLoginDto);
    }
}
