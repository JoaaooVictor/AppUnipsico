using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class ConfiguracaoEstagio : IEntityTypeConfiguration<EstagioModel>
    {
        public void Configure(EntityTypeBuilder<EstagioModel> builder)
        {
            builder
                .HasKey(x => x.EstagioId);

            builder
                .HasOne(x => x.Instituicao)
                .WithMany(x => x.Estagio)
                .HasForeignKey(x => x.InstituicaoId);
        }
    }
}
