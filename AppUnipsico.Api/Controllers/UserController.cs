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
                var userCreate = await _userService.CreateUserAsync(createUserDto);

                if (userCreate != null)
                {
                    return Ok(userCreate);
                }
                else
                {
                    return NotFound("Erro ao cadastrar o usuário!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var authorized = await _userService.ValidateCredentials(userLoginDto);

            if (!authorized)
            {
                return Unauthorized();
            }

            return Ok("Usuário autenticado!");
        }
    }
}
