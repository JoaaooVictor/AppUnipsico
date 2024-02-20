using AppUnipsico.Models.DTOs;
using AppUnipsico.Web.Services.InterfacesWeb;
using AppUnipsico.Web.Utils;
using System.Net.Http.Json;

namespace AppUnipsico.Web.Services.ImplWeb
{
    public class UserServiceWeb : IUserServiceWeb
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public UserServiceWeb(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<ResponseLoginDto> Logar(RequestLoginDto requestLoginDto)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseLoginDto> Logar(RequestLoginDto requestLoginDto)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Post, Url);
        //    var content = new StringContent("{\r\n    \"Cpf\" : \"45506229895\",\r\n    \"Password\": \"Jotinha21*\"\r\n}", null, "application/json");
        //    request.Content = content;
        //    var response = await client.SendAsync(request);
        //    response.EnsureSuccessStatusCode();
        //    Console.WriteLine(await response.Content.ReadAsStringAsync());
        //}

    }
}
