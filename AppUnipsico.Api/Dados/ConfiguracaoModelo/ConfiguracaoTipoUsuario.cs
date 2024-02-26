using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoTipoUsuario : IEntityTypeConfiguration<TipoUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<TipoUsuarioModel> builder)
        {
            builder
                .HasKey(u => u.TipoUsuarioId);

            builder
                .HasData(new TipoUsuarioModel
                {
                    TipoUsuarioId = (int)TipoUsuarioEnum.Paciente,
                    TipoUsuarioDataRegistro = DateTime.Now,
                    TipoUsuarioNome = "Paciente",
                    TipoUsuarioDescricao = "Paciente do consultório",
                    TipoUsuarioEhAdmin = false,
                });

            builder
                .HasData(new TipoUsuarioModel
                {
                    TipoUsuarioId = (int)TipoUsuarioEnum.Aluno,
                    TipoUsuarioDataRegistro = DateTime.Now,
                    TipoUsuarioNome = "Aluno",
                    TipoUsuarioDescricao = "Aluno de Psicologia",
                    TipoUsuarioEhAdmin = false,
                });

            builder
                .HasData(new TipoUsuarioModel
                {
                    TipoUsuarioId = (int)TipoUsuarioEnum.Professor,
                    TipoUsuarioDataRegistro = DateTime.Now,
                    TipoUsuarioNome = "Professor",
                    TipoUsuarioDescricao = "Professor e Admin",
                    TipoUsuarioEhAdmin = true,
                });
        }
    }
}
