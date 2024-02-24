namespace AppUnipsico.Api.Models
{
    public class TipoUsuarioModel
    {
        public int TipoUsuarioId { get; set; }
        public string TipoUsuarioNome { get; set; }
        public string TipoUsuarioDescricao { get; set; }
        public DateTime TipoUsuarioDataRegistro { get; set; }
        public bool TipoUsuarioEhAdmin { get; set; }
    }
}
