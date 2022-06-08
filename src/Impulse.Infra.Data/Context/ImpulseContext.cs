using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Impulse.Domain.Entities;
using Impulse.Infra.Data.Mapping;

namespace Impulse.Infra.Data.Context
{
    public class ImpulseContext : DbContext
    {
        public ImpulseContext()
            : base("ImpulseContext")
        {
        }


        public DbSet<Agendamento> Agendamentos { get; set; }
        
        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            // Configurations
            modelBuilder.Configurations.Add(new AgendamentoConfiguration());
            modelBuilder.Configurations.Add(new MedicoConfiguration());
            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }
    }
}