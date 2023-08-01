namespace eCom_api.Interfaces;

public interface ICRUDRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetEntities();
    Task<TEntity> GetEntityById(int entityId);
    Task<bool> AddEntity(TEntity entity);
    Task<bool> UpdateEntity(TEntity entity);
    Task<bool> DeleteEntity(int entityId);
}
