using FluentValidation;
using FluentValidation.Results;
using Impulse.Infra.CrossCutting.Validacoes;

namespace Impulse.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Senha { get; set; }
        
        public ValidationResult Validar()
        {
            return new UsuarioValidador().Validate(this);
        }
    }

    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(o => o.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O Nome deve ser informado")
                .MaximumLength(50).WithMessage("O Nome não pode conter mais de 100 caracteres");

            RuleFor(o => o.Documento)
                .NotEmpty().WithMessage("O Documento deve ser informado")
                .Must(ValidarDocumento).WithMessage("Documento inválido");

            RuleFor(o => o.Senha)
                .NotEmpty().WithMessage("A senha deve ser informada")
                .MinimumLength(6).WithMessage("A senha deve conter mais de 6 caracteres")
                .MaximumLength(50).WithMessage("A senha deve conter no máximo 50 caracteres");
        }
        
        private static bool ValidarDocumento(string documento)
        {
            return !string.IsNullOrEmpty(documento) && documento.ValidarDocumento();
        }
    }
}