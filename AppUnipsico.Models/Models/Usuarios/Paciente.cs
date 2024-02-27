namespace AppUnipsico.Models.Models.Usuarios
{
    public class Paciente : Usuario
    {
        public virtual IEnumerable<Consulta> Consultas { get; set; }
    }
}
