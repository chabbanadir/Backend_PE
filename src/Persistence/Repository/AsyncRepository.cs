using System.Linq.Expressions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repository;

public class AsyncRepository<T> : IAsyncRepository<T> where T : AuditableEntity
{

    protected readonly ApplicationDbContext _applicationDbContext;

    public AsyncRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default)
    {

        IQueryable<T> query = _applicationDbContext.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include).Where(x => !x.IsDeleted);

        return await query.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _applicationDbContext.Set<T>();


        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(predicate).Where(x => !x.IsDeleted).ToArrayAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _applicationDbContext.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        var res =  await query.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken: cancellationToken);

        return res;
    }

    public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }



    public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<bool> Update(T entity, CancellationToken cancellationToken = default)
    {
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _applicationDbContext.Set<T>().FindAsync(id);

        if (entity != null)
        {
            entity.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }




/*    public async Task<IReadOnlyList<T>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default)
    {


        IQueryable<T> query = _applicationDbContext.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include).Where(x => !x.IsDeleted);


        return await query
            .Where(x => !x.IsDeleted)
              .Skip((page - 1) * size).Take(size)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    }*/


/*    public async Task<T> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default)
    {

        IQueryable<T> query = _applicationDbContext.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include).Where(x => !x.IsDeleted);

        var res = await query.Where(x => !x.IsDeleted).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken: cancellationToken);

        return res;
    }*/


/*    public async Task<bool> Update(T entity, CancellationToken cancellationToken = default)
    {
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }*/
/*    public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return entity;

    }*/
/*    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _applicationDbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }*/
/*    public async Task<IQueryable<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _applicationDbContext.Set<T>();


        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);


        return await Task.FromResult(query.Where(predicate).AsQueryable());


        // return await query.Where(predicate).ToArrayAsync(cancellationToken);
    }*/
/*    public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }*/


}