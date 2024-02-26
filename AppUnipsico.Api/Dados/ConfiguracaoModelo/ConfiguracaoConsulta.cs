using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoConsulta : IEntityTypeConfiguration<ConsultaModel>
    {
        public void Configure(EntityTypeBuilder<ConsultaModel> builder)
        {
            builder.
                 HasKey(x => x.ConsultaId);

            builder
                .HasOne(x => x.Paciente)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.PacienteId);
        }
    }
}
