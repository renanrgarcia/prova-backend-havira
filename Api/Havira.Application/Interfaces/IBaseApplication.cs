namespace Havira.Application.Interfaces
{
    public interface IBaseApplication<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task Create(T viewModel);
        Task<bool> Update(T viewModel);
        Task<bool> Remove(Guid id);
    }
}