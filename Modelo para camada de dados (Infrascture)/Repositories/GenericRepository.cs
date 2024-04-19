using Microsoft.EntityFrameworkCore;
using Modelo_para_application__Clean_arch_.Interfaces.Repository;
using Modelo_para_camada_de_dados__Infrascture_.Context;
using System.Linq.Expressions;

namespace Modelo_para_camada_de_dados__Infrascture_.Repositories;
public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ExampleDbContext _context;
    private readonly DbSet<TEntity> _entity;

    protected GenericRepository(ExampleDbContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filterExpression = null)
    {
        var dbSet = TrackingItem(false);

        return dbSet.Where(filterExpression).AsEnumerable();
    }

    public async Task<TEntity> GetByIdAsync(int id, bool tracking)
    {
        var dbSet = TrackingItem(tracking);

        return dbSet.ToList().Find(x => x.Equals(id));
    }

    public virtual async Task<bool> PostAsync(TEntity entity, CancellationToken ct)
    {
        await _entity.AddAsync(entity);

        var result = await _context.SaveChangesAsync(ct);

        return result > 0 ? true : false;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        _entity.Update(entity);

        var result = await _context.SaveChangesAsync(ct);

        return result > 0 ? true : false;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken ct)
    {
        _entity.Remove(entity);

        var result = await _context.SaveChangesAsync(ct);

        return result > 0 ? true : false;
    }

    private IQueryable<TEntity> TrackingItem(bool tracking)
    {
        if (tracking)
            return _entity;

        return _entity.AsNoTracking();
    }
}