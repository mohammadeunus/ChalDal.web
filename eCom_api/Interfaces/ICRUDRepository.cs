namespace eCom_api.Interfaces;

public interface ICRUDRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetEntities();
    Task<TEntity> GetEntity(int entityId);
    Task<TEntity> AddEntity(TEntity entity);
    Task<TEntity> UpdateEntity(TEntity entity);
    void DeleteEntity(int entityId);
}
