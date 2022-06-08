using System.ComponentModel.DataAnnotations;

namespace Impulse.Domain.ViewModels.Agendamentos
{
    public class AgendamentosViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Paciente")]
        public string Paciente { get; set; }

        [Display(Name = "Médico")]
        public string Medico { get; set; }

        [Display(Name = "Data")]
        public string Data { get; set; }
    }
}