using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class StageConfiguration : IEntityTypeConfiguration<StageModel>
    {
        public void Configure(EntityTypeBuilder<StageModel> builder)
        {
            builder
                .HasKey(x => x.StageId);

            builder
                .HasOne(x => x.Institution)
                .WithMany(x => x.Stages)
                .HasForeignKey(x => x.InstitutionId);
        }
    }
}
