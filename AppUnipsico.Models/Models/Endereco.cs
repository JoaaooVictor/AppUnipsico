namespace AppUnipsico.Models.Models
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; } 
        public string Numero { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; } 
        public string Cep { get; set; } 
        public virtual Instituicao? Instituicao { get; set; }
    }
}
