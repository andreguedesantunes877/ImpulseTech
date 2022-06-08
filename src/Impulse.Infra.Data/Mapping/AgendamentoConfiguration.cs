using System.Data.Entity.ModelConfiguration;
using Impulse.Domain.Entities;

namespace Impulse.Infra.Data.Mapping
{
    public class AgendamentoConfiguration : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoConfiguration()
        {
            ToTable("AGENDAMENTOS");
            
            HasKey(o => o.Id);

            HasRequired(o => o.Paciente)
                .WithMany(o => o.Agendamentos)
                .HasForeignKey(o => o.PacienteId);

            HasRequired(o => o.Medico)
                .WithMany(o => o.Agendamentos)
                .HasForeignKey(o => o.MedicoId);

            Property(o => o.DataHoraConsulta)
                .IsRequired();
        }
    }
}