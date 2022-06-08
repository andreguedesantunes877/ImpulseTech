using System.Data.Entity.ModelConfiguration;
using Impulse.Domain.Entities;

namespace Impulse.Infra.Data.Mapping
{
    public class MedicoConfiguration : EntityTypeConfiguration<Medico>
    {
        public MedicoConfiguration()
        {
            ToTable("MEDICOS");
            
            HasKey(o => o.Id);

            Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(o => o.Crm)
                .IsRequired()
                .HasMaxLength(10);

            Property(o => o.Especialidade)
                .IsRequired();
        }
    }
}