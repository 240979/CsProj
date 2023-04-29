using ElectronicStorage.Persistence.Models;

namespace ElectronicStorage.Persistence.Repositories;

public interface IRepository <TEntity> where TEntity : EntityBase
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> Get(Guid id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity?> Delete(Guid id);
}