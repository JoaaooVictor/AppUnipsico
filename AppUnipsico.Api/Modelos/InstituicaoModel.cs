namespace AppUnipsico.Api.Models
{
    public class InstituicaoModel
    {
        public Guid InstituicaoId { get; set; }
        public string InstituicaoNome { get; set; }
        public Guid EnderecoId { get; set; }
        public virtual EnderecoModel Endereco { get; set; }
        public virtual ICollection<EstagioModel> Estagio { get; set; }
    }
}
