using FluentValidation;
using Havira.Business.Models.ContextoLocalizacao;

namespace Havira.Business.Models.ContextoLocalizacao.Validations
{
    public class LocalizacaoValidation : AbstractValidator<Localizacao>
    {
        public LocalizacaoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(x => x.Categoria)
                .IsInEnum()
                .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => x.Coordenadas)
                .Must(x => x != null && x.X != 0 && x.Y != 0)
                .WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}