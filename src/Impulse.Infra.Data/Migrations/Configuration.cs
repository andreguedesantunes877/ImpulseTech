using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using Impulse.Domain.Entities;
using Impulse.Infra.Data.Context;
using Impulse.Infra.Data.Migrations.Seed;

namespace Impulse.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ImpulseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ImpulseContext context)
        {
            ExecuteSeed<ConfigurationsSeed, Configuration>(context);
            ExecuteSeed<UsuarioSeed, Usuario>(context);
            ExecuteSeed<MedicoSeed, Medico>(context);
        }
        
        private static void ExecuteSeed<TSeed, TEntity>(ImpulseContext context, bool onlyEmpty = false) where TSeed : ISeed<ImpulseContext>, new() where TEntity : class
        {
            if (onlyEmpty && context.Set<TEntity>().Any())
                return;

            var seed = new TSeed();
            var applicationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            if (!Directory.Exists(applicationPath))
                Directory.CreateDirectory(applicationPath);

            using (var outputFile = new StreamWriter(Path.Combine(applicationPath, "LogAdquirenteSeed.txt"), true))
            {
                try
                {
                    seed.Execute(context);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbException)
                {
                    foreach (var eve in dbException.EntityValidationErrors)
                    {
                        outputFile.WriteLine(
                            "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            outputFile.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName,
                                ve.ErrorMessage);
                        }
                    }
                }
                catch (Exception e)
                {
                    outputFile.WriteLine($"EXCEPTION DO SEED: {e}");
                }
            }
        }
    } 
}