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

        protected BaseApplication(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificate(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificate(error.ErrorMessage);
            }
        }

        protected void Notificate(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void Notificate(IEnumerable<string> messages)
        {
            var notifications = new List<Notification>();

            foreach (var message in messages)
                notifications.Add(new Notification(message));

            _notificator.Handle(notifications);
        }

        protected bool ExecuteValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificate(validator);
            return false;
        }
    }
}