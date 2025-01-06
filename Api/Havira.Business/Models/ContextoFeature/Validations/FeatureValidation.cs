using FluentValidation;
using Havira.Business.Models.ContextoFeature;

namespace Havira.Business.Models.ContextoFeature.Validations
{
    public class FeatureValidation : AbstractValidator<Feature>
    {
        public FeatureValidation()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}