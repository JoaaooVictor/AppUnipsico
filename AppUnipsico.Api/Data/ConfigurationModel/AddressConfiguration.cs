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
        }

    }
}
