namespace AppUnipsico.Api.Models
{
    public class EnderecoModel
    {
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public virtual InstituicaoModel? Instituicao { get; set; }
    }
}
