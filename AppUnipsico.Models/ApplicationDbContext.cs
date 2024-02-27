using AppUnipsico.Models.Models;
using AppUnipsico.Models.Models.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Models
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Funcao, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Usuparios
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        //outras entidades
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estagio> Estagios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
      
    }
}
