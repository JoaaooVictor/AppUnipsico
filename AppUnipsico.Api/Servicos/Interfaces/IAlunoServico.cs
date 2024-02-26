using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Modelos.DTOs;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IAlunoServico
    {
        public TrataRetornoDTO GeraPdfEstagio(AlunoModel aluno);
        public string CarregaDadosDoAluno(string arquivoHtml, AlunoModel aluno, string nomeDoArquivoPdf);
        public string RetornaNomeDoArquivo(AlunoModel aluno);
        public void SalvaArquivoPdf(Stream streamPdf, string nomeDoArquivoPdf);
    }
}
