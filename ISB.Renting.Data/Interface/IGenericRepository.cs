using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ISB.Renting.Data.Interface;

public interface IGenericRepository<T> where T : class
{
    T GetById(Guid id);
    IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
    IQueryable<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
