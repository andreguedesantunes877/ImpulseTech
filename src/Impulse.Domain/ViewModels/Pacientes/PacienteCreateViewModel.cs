using System.ComponentModel.DataAnnotations;

namespace Impulse.Domain.ViewModels.Pacientes
{
    public class PacienteCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome deve ser preenchido")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode conter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Documento deve ser preenchido")]
        [StringLength(11, ErrorMessage = "O campo Documento não pode ter mais de 11 caracteres")]
        public string Documento { get; set; }

        [Display(Name = "Número do convênio")]
        public string NumeroConvenio { get; set; }
    }
}