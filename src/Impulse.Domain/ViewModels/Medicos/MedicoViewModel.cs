using Impulse.Domain.Enumerations;

namespace Impulse.Domain.ViewModels.Medicos
{
    public class MedicoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Crm { get; set; }

        public EEspecialidadesMedica Especialidade { get; set; }
    }
}