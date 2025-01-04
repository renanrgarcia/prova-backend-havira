namespace Havira.Application.Interfaces
{
    public interface IBaseApplication<T> : IDisposable
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid Id);
        Task Adicionar(T viewModel);
        Task Atualizar(T viewModel);
        Task<bool> Remover(Guid id);
    }
}