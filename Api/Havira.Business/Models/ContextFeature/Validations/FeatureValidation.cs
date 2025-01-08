using FluentValidation;

namespace Havira.Business.Models.ContextFeature.Validations
{
    public class FeatureValidation : AbstractValidator<Feature>
    {
        public FeatureValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .IsInEnum().WithMessage("O campo {PropertyName} deve ser um valor válido.");

            RuleFor(x => x.Point.Coordinate.X)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThanOrEqualTo(-180).WithMessage("O campo {PropertyName} deve ser maior ou igual a {ComparisonValue}.")
                .LessThanOrEqualTo(180).WithMessage("O campo {PropertyName} deve ser menor ou igual a {ComparisonValue}.");

            RuleFor(x => x.Point.Coordinate.Y)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThanOrEqualTo(-90).WithMessage("O campo {PropertyName} deve ser maior ou igual a {ComparisonValue}.")
                .LessThanOrEqualTo(90).WithMessage("O campo {PropertyName} deve ser menor ou igual a {ComparisonValue}.");
        }
    }
}