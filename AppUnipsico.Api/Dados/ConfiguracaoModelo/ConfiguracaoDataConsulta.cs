using AppUnipsico.Api.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoDataConsulta : IEntityTypeConfiguration<DataConsultaModel>
    {
        public void Configure(EntityTypeBuilder<DataConsultaModel> builder)
        {
            builder
                .HasKey(x => x.DataConsultaId);

            builder
                .HasOne(x => x.Consulta)
                .WithOne(x => x.DataConsulta)
                .HasForeignKey<DataConsultaModel>(x => x.ConsultaId);
        }
    }
}
