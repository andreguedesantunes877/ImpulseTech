using System.Collections.Generic;
using Impulse.Domain.Enumerations;

namespace Impulse.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Crm { get; set; }

        public EEspecialidadesMedica Especialidade { get; set; }
        
        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}