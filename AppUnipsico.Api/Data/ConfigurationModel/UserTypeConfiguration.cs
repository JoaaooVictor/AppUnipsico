using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserTypeModel>
    {
        public void Configure(EntityTypeBuilder<UserTypeModel> builder)
        {
            builder
                .HasKey(u => u.UserTypeModelId);

            builder
                .HasData(new UserTypeModel
                {
                    UserTypeModelId = (int)UserTypeEnum.Patient,
                    UserTypeDateCreated = DateTime.Now,
                    UserTypeName = "Paciente",
                    UserTypeDescription = "Paciente do consultório",
                    UserTypeIsAdmin = false,
                });

            builder
                .HasData(new UserTypeModel
                {
                    UserTypeModelId = (int)UserTypeEnum.Student,
                    UserTypeDateCreated = DateTime.Now,
                    UserTypeName = "Aluno",
                    UserTypeDescription = "Aluno de Psicologia",
                    UserTypeIsAdmin = false,
                });

            builder
                .HasData(new UserTypeModel
                {
                    UserTypeModelId = (int)UserTypeEnum.Teacher,
                    UserTypeDateCreated = DateTime.Now,
                    UserTypeName = "Professor",
                    UserTypeDescription = "Professor e Admin",
                    UserTypeIsAdmin = true,
                });
        }
    }
}
