using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoInstituicao : IEntityTypeConfiguration<InstituicaoModel>
    {
        public void Configure(EntityTypeBuilder<InstituicaoModel> builder)
        {
            builder
                .HasKey(x => x.InstituicaoId);

            builder
                .HasMany(x => x.Estagio)
                .WithOne(x => x.Instituicao)
                .HasForeignKey(x => x.InstituicaoId);
        }
    }
}
