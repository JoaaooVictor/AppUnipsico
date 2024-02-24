using AppUnipsico.Models.DTOs;
using AppUnipsico.Web.Services.InterfacesWeb;
using AppUnipsico.Web.Utils;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AppUnipsico.Web.Services.ImplWeb
{
    public class UsuarioServicoWeb : IUsuarioServicoWeb
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicoWeb(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespostaLoginDTO> Logar(RequisicaoLoginDTO requestLoginDto)
        {
            var responseApi = await _httpClient.PostAsJsonAsync(EndPoints.Login, requestLoginDto);

            return await  responseApi.Content.ReadFromJsonAsync<RespostaLoginDTO>();
        }
    }
}
