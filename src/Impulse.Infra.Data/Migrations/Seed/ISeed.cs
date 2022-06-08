using System.Data.Entity;

namespace Impulse.Infra.Data.Migrations.Seed
{
    public interface ISeed<in TContext> where TContext : DbContext
    {
        void Execute(TContext context);   
    }
}