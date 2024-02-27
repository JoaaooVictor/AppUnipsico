using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServico _alunoServico;

        public AlunoController(IAlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }

        [HttpGet]
        [Route("gera-documento")]
        public async Task<ActionResult> GeraDocumentoEstagio()
        {
            var alunoId = "0000000000";
            var aluno = await _alunoServico.BuscaAlunoPorCpf(alunoId);
            _alunoServico.GeraPdfEstagio(aluno!);

            return Ok();
        }
    }
}
