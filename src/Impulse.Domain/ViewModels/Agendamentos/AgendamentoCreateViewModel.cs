using System;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Domain.ViewModels.Agendamentos
{
    public class AgendamentoCreateViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Paciente é de preenchimento obrigatório")]
        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O campo Médico é de preenchimento obrigatório")]
        [Display(Name = "Médico")]
        public int MedicoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [Required(ErrorMessage = "O campo Data é de preenchimento obrigatório")]
        [Display(Name = "Data")]
        public DateTime DataConsulta { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        [Required(ErrorMessage = "O campo Hora é de preenchimento obrigatório")]
        [Display(Name = "Hora")]
        public DateTime HoraConsulta { get; set; }
    }
}