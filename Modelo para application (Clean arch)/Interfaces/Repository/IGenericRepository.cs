using System.Linq.Expressions;

namespace Modelo_para_application__Clean_arch_.Interfaces.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filterExpression = null);
    Task<TEntity> GetByIdAsync(int id, bool tracking);
    Task<bool> PostAsync(TEntity entity, CancellationToken ct);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken ct);
    Task<bool> DeleteAsync(TEntity entity, CancellationToken ct);
}