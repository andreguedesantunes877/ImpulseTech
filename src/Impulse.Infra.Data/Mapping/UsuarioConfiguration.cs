using System.Data.Entity.ModelConfiguration;
using Impulse.Domain.Entities;

namespace Impulse.Infra.Data.Mapping
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("USUARIOS");

            HasKey(o => o.Id);

            Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(o => o.Documento)
                .IsRequired()
                .HasMaxLength(14);

            Property(o => o.Senha)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}