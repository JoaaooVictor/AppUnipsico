using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                var result = await _userService.CreateUserAsync(createUserDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar usuário no banco.");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginUserAsync(UserLoginDto userLoginDto)
        {
            try
            {
                var result = await _userService.Login(userLoginDto);

                if (result is null)
                {
                    return BadRequest("Usuário não autenticado! Verifique as credênciais");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
