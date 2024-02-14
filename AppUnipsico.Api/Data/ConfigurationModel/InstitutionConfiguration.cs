using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<InstitutionModel>
    {
        public void Configure(EntityTypeBuilder<InstitutionModel> builder)
        {
            builder
                .HasKey(x => x.InstitutionId);

            builder
                .HasMany(x => x.Stages)
                .WithOne(x => x.Institution)
                .HasForeignKey(x => x.InstitutionId);
        }
    }
}
