using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class ConsultConfiguration : IEntityTypeConfiguration<ConsultModel>
    {
        public void Configure(EntityTypeBuilder<ConsultModel> builder)
        {
            builder.
                 HasKey(x => x.ConsultId);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Consults)
                .HasForeignKey(x => x.StudentId);

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Consults)
                .HasForeignKey(x => x.TeacherId);

            builder
                .HasOne(x => x.Patient)
                .WithMany(x => x.Consults)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
