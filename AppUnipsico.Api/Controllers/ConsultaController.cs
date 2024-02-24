using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaController(IConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        [HttpPost]
        [Route("agendar-consulta")]
        public async Task<ActionResult> ScheduleConsult(AgendaConsultaDTO agendaConsultaDTO)
        {
            var ok = await _consultaServico.AgendaConsulta(agendaConsultaDTO.ConsultDate, agendaConsultaDTO.PatientId);

            if (ok)
            {
                return Ok(agendaConsultaDTO);
            }

            return BadRequest("Erro ao agendar a consulta, tente novamente!");
        }
    }
}
