using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Data.ConfigurationModel;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TipoUsuarioModel> TiposUsuarios { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<InstituicaoModel> Instituicoes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<EstagioModel> Estagios { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracaoTipoUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracaoUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracaoConsulta());
            modelBuilder.ApplyConfiguration(new ConfiguracaoEstagio());
            modelBuilder.ApplyConfiguration(new ConfiguracaoInstituicao());
            modelBuilder.ApplyConfiguration(new ConfiguracaoEndereco());
        }
    }
}
