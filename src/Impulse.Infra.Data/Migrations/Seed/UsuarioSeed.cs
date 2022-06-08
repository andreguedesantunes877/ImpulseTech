using System.Data.Entity.Migrations;
using Impulse.Domain.Entities;
using Impulse.Infra.Data.Context;

namespace Impulse.Infra.Data.Migrations.Seed
{
    public class UsuarioSeed : ISeed<ImpulseContext>
    {
        public void Execute(ImpulseContext context)
        {
            context.Usuarios.AddOrUpdate(o => new {o.Documento, o.Nome}, new Usuario
                {
                    Documento = "00000000000",
                    Nome = "Administrador",
                    Senha = "123456"
                },
                new Usuario
                {
                    Documento = "40988548054",
                    Nome = "Atendente",
                    Senha = "123456"
                });
        }
    }
}