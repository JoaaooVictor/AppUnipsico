using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class UserConfiguration : IEntityTypeConfiguration<UserBaseModel>
    {
        public void Configure(EntityTypeBuilder<UserBaseModel> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .HasOne(u => u.UserType)
                .WithOne(u => u.UserModel)
                .HasForeignKey<UserBaseModel>(u => u.UserTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(u => u.UserCpf)
                .IsUnique();

            builder
                .HasIndex(u => u.UserEmail)
                .IsUnique();
        }
    }
}
