using System.Data.Entity.ModelConfiguration;
using Impulse.Domain.Entities;

namespace Impulse.Infra.Data.Mapping
{
    public class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            ToTable("PACIENTES");
            
            HasKey(o => o.Id);

            Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(o => o.Documento)
                .IsRequired()
                .HasMaxLength(14);

            Property(o => o.NumeroConvenio)
                .IsOptional()
                .HasMaxLength(50);
        }
    }
}