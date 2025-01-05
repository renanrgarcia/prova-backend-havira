using Havira.Business.Notificacoes;

namespace Havira.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
        void Handle(IEnumerable<Notificacao> notificacoes);
    }
}