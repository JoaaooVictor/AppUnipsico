using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder
                .HasKey(a => a.AddressId);

            builder
                 .HasOne(x => x.Institution)
                 .WithOne(x => x.Address)
                 .HasForeignKey<InstitutionModel>(x => x.AddressId);

            builder
                .Property(x => x.PublicPlace)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Neighborhood)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Town)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.ZipCode)
                .HasColumnType("varchar(20)");
        }
    }
}
