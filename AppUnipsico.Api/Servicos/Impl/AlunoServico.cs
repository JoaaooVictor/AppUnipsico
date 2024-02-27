using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Api.Utilidades;
using AppUnipsico.Models;
using AppUnipsico.Models.Models.Usuarios;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class AlunoServico : IAlunoServico
    {
        private readonly ApplicationDbContext _context;

        public AlunoServico(ApplicationDbContext context)
        {
            _context = context;
        }

        public TrataRetornoDTO GeraPdfEstagio(Aluno aluno)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            string nomeDoArquivoPdf = RetornaNomeDoArquivo(aluno);
            var arquivoHtml = HtmlDocument.HtmlEncode(nomeDoArquivoPdf);
            var conteudoHtmlTratado = CarregaDadosDoAluno(arquivoHtml, aluno, nomeDoArquivoPdf);

            using (var streamPdf = HtmlUtilidades.ConverteHtmlParaPdf(conteudoHtmlTratado))
            {
                SalvaArquivoPdf(streamPdf, nomeDoArquivoPdf);
            }

            return trataRetornoDTO;
        }

        public string CarregaDadosDoAluno(string arquivoHtml, Aluno aluno, string nomeDoArquivoPdf)
        {
            var conteudohtmlTratado = arquivoHtml;

            return conteudohtmlTratado;
        }

        public void SalvaArquivoPdf(Stream streamPdf, string nomeDoArquivoPdf)
        {
            var caminhoArquivoPdf = Path.Combine(@"C:\Users\joaov\OneDrive\Documentos\PDFs\", nomeDoArquivoPdf);

            using (var ms = new FileStream(caminhoArquivoPdf, FileMode.Create))
            {
                streamPdf.CopyTo(ms);
                streamPdf.Seek(0, SeekOrigin.Begin);
            }
        }

        public string RetornaNomeDoArquivo(Aluno aluno)
        {
            var nomeArquivo = $"aluno_{aluno.Ra}_{DateTime.Now}.pdf";

            return nomeArquivo;
        }

        public async Task<Aluno?> BuscaAlunoPorCpf(string cpf)
        {
            return await _context.Alunos.Where(x => x.Cpf == cpf).Include(x => x.TipoUsuario).FirstOrDefaultAsync();
        }
    }
}
