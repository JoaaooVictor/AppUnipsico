namespace AppUnipsico.Api.Models
{
    public class PacienteModel : UsuarioModel
    {
        public virtual IEnumerable<ConsultaModel> Consultas { get; set; }
    }
}
