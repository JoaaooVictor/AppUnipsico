namespace AppUnipsico.Models.Models
{
    public class Instituicao
    {
        public Guid InstituicaoId { get; set; }
        public string InstituicaoNome { get; set; }
        public Guid EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Estagio> Estagio { get; set; }
    }
}
