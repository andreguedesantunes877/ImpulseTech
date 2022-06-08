using System;

namespace Impulse.Domain.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        public DateTime DataHoraConsulta { get; set; }
        
        public virtual Paciente Paciente { get; set; }
        
        public virtual Medico Medico { get; set; }
    }
}