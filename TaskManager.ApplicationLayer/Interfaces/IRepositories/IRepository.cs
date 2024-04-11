namespace TaskManager.ApplicationLayer.Interfaces.IRepositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Update(T entity);
    }
}