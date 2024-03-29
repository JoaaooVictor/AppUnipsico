﻿using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("api/consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaController(IConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        [HttpPost]
        [Route("agendar")]
        public async Task<ActionResult> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO)
        {
            try
            {
                var resposta = await _consultaServico.AgendarConsulta(agendaConsultaDTO);

                if (!resposta.Erro)
                {
                    return Ok(resposta);
                }

                return BadRequest(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("datas")]
        public async Task<ActionResult> GerarDatasConsultas()
        {
            await _consultaServico.LerEInserirConsultas();

            return Ok();
        }
    }
}
