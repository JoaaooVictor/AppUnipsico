using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Dados.ConfiguracaoModelo
{
    public class ConfiguracaoEndereco : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder
                .HasKey(a => a.EnderecoId);

            builder
                 .HasOne(x => x.Instituicao)
                 .WithOne(x => x.Endereco)
                 .HasForeignKey<InstituicaoModel>(x => x.EnderecoId);

            builder
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Bairro)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Cidade)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Cep)
                .HasColumnType("varchar(20)");
        }
    }
}
