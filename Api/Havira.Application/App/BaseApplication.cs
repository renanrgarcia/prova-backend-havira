using FluentValidation;
using FluentValidation.Results;
using Havira.Business.Interfaces;
using Havira.Business.Models;
using Havira.Business.Notificacoes;

namespace Havira.Application.App
{
    public abstract class BaseApplication
    {
        private readonly INotificador _notificador;

        protected BaseApplication(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected void Notificar(IEnumerable<string> mensagens)
        {
            var notificacoes = new List<Notificacao>();

            foreach (var mensagem in mensagens)
                notificacoes.Add(new Notificacao(mensagem));

            _notificador.Handle(notificacoes);
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }
    }
}