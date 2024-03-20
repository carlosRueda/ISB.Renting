using ISB.Renting.Data.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace ISB.Renting.Data.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly IsbDbContext context;
    public GenericRepository(IsbDbContext context)
    {
        this.context = context;
    }
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities);
    }
    public IQueryable<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        var query = context.Set<T>().Where(expression);
        if (includes != null)
            query = includes(query);
        return query;
    }
    public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        var query = context.Set<T>().AsQueryable();
        if (includes != null)
            query = includes(query);
        return query;
    }
    public T GetById(Guid id)
    {
        return context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }

}
