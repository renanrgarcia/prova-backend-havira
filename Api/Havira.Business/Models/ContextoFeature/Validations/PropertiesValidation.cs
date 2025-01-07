using FluentValidation;
using Havira.Business.Models.ContextoFeature;

namespace Havira.Business.Models.ContextoFeature.Validations
{
    public class PropertiesValidation : AbstractValidator<Properties>
    {
        public PropertiesValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(x => x.Categoria)
                .IsInEnum()
                .WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}