using AppUnipsico.Api.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoAluno : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder
                .HasMany(x => x.Estagios)
                .WithOne(x => x.Aluno)
                .HasForeignKey(x => x.AlunoId);
        }
    }
}
