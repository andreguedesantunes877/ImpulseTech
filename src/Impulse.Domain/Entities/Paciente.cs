using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Impulse.Infra.CrossCutting.Validacoes;

namespace Impulse.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string NumeroConvenio { get; set; }
        
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        
        public ValidationResult Validar()
        {
            return new PacienteValidador().Validate(this);
        }
    }

    public class PacienteValidador : AbstractValidator<Paciente>
    {
        public PacienteValidador()
        {
            RuleFor(o => o.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O Nome deve ser informado")
                .MaximumLength(50).WithMessage("O Nome não pode conter mais de 100 caracteres");
            
            RuleFor(o => o.Documento)
                .NotEmpty().WithMessage("O Documento deve ser informado")
                .Must(ValidarDocumento).WithMessage("Documento inválido");
        }
        
        private static bool ValidarDocumento(string documento)
        {
            return !string.IsNullOrEmpty(documento) && documento.ValidarDocumento();
        }
    }
}