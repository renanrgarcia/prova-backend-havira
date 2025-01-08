using FluentValidation;
using FluentValidation.Results;
using Havira.Business.Helpers.Notification;
using Havira.Business.Interfaces;
using Havira.Business.Models;

namespace Havira.Application.App
{
    public abstract class BaseApplication
    {
        private readonly INotificator _notificator;

        protected BaseApplication(INotificator notificador)
        {
            _notificator = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void Notificar(IEnumerable<string> messages)
        {
            var notifications = new List<Notification>();

            foreach (var message in messages)
                notifications.Add(new Notification(message));

            _notificator.Handle(notifications);
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