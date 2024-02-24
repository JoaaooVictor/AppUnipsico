﻿using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico userService)
        {
            _usuarioServico = userService;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult> CriaUsuarioAsync(CriaUsuarioDTO createUserDto)
        {
            try
            {
                var usuarioCriado = await _usuarioServico.CriaUsuarioAsync(createUserDto);

                if (usuarioCriado != null)
                {
                    return Ok(usuarioCriado);
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
        public async Task<ActionResult> LogaUsuarioAsync(RequisicaoLoginDTO userLoginDto)
        {
            var autorizado = await _usuarioServico.ValidaCredenciaisAsync(userLoginDto);

            if (string.IsNullOrEmpty(autorizado))
            {
                return Unauthorized();
            }

            return Ok(autorizado);
        }
    }
}