using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Api.Utilidades;
using HtmlAgilityPack;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class AlunoServico : IAlunoServico
    {
        private readonly AppDbContext _context;

        public AlunoServico(AppDbContext context)
        {
            _context = context;
        }

        public TrataRetornoDTO GeraPdfEstagio(AlunoModel aluno)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            string nomeDoArquivoPdf = RetornaNomeDoArquivo(aluno);
            var arquivoHtml = HtmlDocument.HtmlEncode(nomeDoArquivoPdf);
            var conteudoHtmlTratado = CarregaDadosDoAluno(arquivoHtml, aluno, nomeDoArquivoPdf);

            using(var streamPdf = HtmlUtilidades.ConverteHtmlParaPdf(conteudoHtmlTratado))
            {
                SalvaArquivoPdf(streamPdf, nomeDoArquivoPdf);
            }

            return trataRetornoDTO;
        }

        public string CarregaDadosDoAluno(string arquivoHtml, AlunoModel aluno, string nomeDoArquivoPdf)
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

        public string RetornaNomeDoArquivo(AlunoModel aluno)
        {
            var nomeArquivo = $"aluno_{aluno.Ra}_{DateTime.Now}.pdf";

            return nomeArquivo; 
        }
    }
}
