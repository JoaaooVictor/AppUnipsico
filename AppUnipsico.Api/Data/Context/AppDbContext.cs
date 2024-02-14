using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Data.ConfigurationModel;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserBaseModel> Users { get; set; }
        public DbSet<UserTypeModel> UserTypes { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<InstitutionModel> Institutions { get; set; }
        public DbSet<AddressModel> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultConfiguration());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
