using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Servicos.Interfaces
{
    public interface IPacienteServico
    {
        public Task<PacienteModel> CriaPacienteAsync(UsuarioModel usuarioModel);
    }
}
