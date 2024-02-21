using AppUnipsico.Models.DTOs;
using AppUnipsico.Web.Services.InterfacesWeb;
using AppUnipsico.Web.Utils;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AppUnipsico.Web.Services.ImplWeb
{
    public class UserServiceWeb : IUserServiceWeb
    {
        private readonly HttpClient _httpClient;

        public UserServiceWeb(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseLoginDto> Logar(RequestLoginDto requestLoginDto)
        {
            ResponseLoginDto conteudo = new();
            var response = await _httpClient.PostAsJsonAsync(EndPoints.Login, requestLoginDto);

            if (response.IsSuccessStatusCode)
            {
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                {
                    conteudo = await JsonSerializer.DeserializeAsync<ResponseLoginDto>(stream);
                }
            }
            return conteudo;
        }
    }
}
