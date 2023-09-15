namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
