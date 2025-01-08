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

            RuleFor(x => x.Geometry.Coordinate.X)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThanOrEqualTo(-180).WithMessage("O campo {PropertyName} deve ser maior ou igual a {ComparisonValue}.")
                .LessThanOrEqualTo(180).WithMessage("O campo {PropertyName} deve ser menor ou igual a {ComparisonValue}.");

            RuleFor(x => x.Geometry.Coordinate.Y)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThanOrEqualTo(-90).WithMessage("O campo {PropertyName} deve ser maior ou igual a {ComparisonValue}.")
                .LessThanOrEqualTo(90).WithMessage("O campo {PropertyName} deve ser menor ou igual a {ComparisonValue}.");
        }
    }
}