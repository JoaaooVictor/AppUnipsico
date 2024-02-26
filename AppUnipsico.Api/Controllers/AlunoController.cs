using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppUnipsico.Api.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServico _alunoServico;

        public AlunoController(IAlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }

        [HttpGet]
        [Route("gera-documento-estagio")]
        public ActionResult GeraDocumentoEstagio(AlunoModel alunoModel)
        {
            _alunoServico.GeraPdfEstagio(alunoModel);

            return Ok();
        }
    }
}
