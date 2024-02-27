using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Models.Models.Usuarios;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IAlunoServico
    {
        public TrataRetornoDTO GeraPdfEstagio(Aluno aluno);
        public string CarregaDadosDoAluno(string arquivoHtml, Aluno aluno, string nomeDoArquivoPdf);
        public string RetornaNomeDoArquivo(Aluno aluno);
        public void SalvaArquivoPdf(Stream streamPdf, string nomeDoArquivoPdf);
        public Task<Aluno?> BuscaAlunoPorCpf(string cpf);
    }
}
