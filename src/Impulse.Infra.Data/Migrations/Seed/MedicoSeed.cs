using System.Data.Entity.Migrations;
using Impulse.Domain.Entities;
using Impulse.Domain.Enumerations;
using Impulse.Infra.Data.Context;

namespace Impulse.Infra.Data.Migrations.Seed
{
    public class MedicoSeed : ISeed<ImpulseContext>
    {
        public void Execute(ImpulseContext context)
        {
            context.Medicos.AddOrUpdate(o => new {o.Nome, o.Crm},
                new Medico {Nome = "Dr. Igor Guterres Gravato", Crm = "00001", Especialidade = EEspecialidadesMedica.Cardiologista},
                new Medico {Nome = "Dr. Izabella Seabra Velasco", Crm = "00002", Especialidade = EEspecialidadesMedica.Cirurgiao},
                new Medico {Nome = "Dr. Bernardo Monte Galvão", Crm = "00003", Especialidade = EEspecialidadesMedica.Dermatologista},
                new Medico {Nome = "Dr. Marina Eiró Loio", Crm = "00004", Especialidade = EEspecialidadesMedica.Endocrinologista},
                new Medico {Nome = "Dr. Thomas Balsemão Farias", Crm = "00005", Especialidade = EEspecialidadesMedica.Gastroenterologista},
                new Medico {Nome = "Dr. Wilson Gorjão Balsemão", Crm = "00006", Especialidade = EEspecialidadesMedica.Geriatra},
                new Medico {Nome = "Dr. Martina Torreiro Lousã", Crm = "00007", Especialidade = EEspecialidadesMedica.Ginecologista},
                new Medico {Nome = "Dr. Dario Quirino Macieira", Crm = "00008", Especialidade = EEspecialidadesMedica.Nefrologista}
            );
        }
    }
}