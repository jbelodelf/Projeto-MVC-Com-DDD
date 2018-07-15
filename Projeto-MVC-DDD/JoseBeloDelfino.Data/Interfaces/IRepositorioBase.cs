using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace JoseBeloDelfino.Data.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        bool Any();
        bool Any(Expression<Func<T, bool>> expression);
        int Count();
        int Count(Expression<Func<T, bool>> expression);
        IQueryable<T> Select(params string[] includes);
        IQueryable<T> Select(Expression<Func<T, bool>> expression, params string[] includes);
        T Insert(T entity);
        IEnumerable<T> Insert(IEnumerable<T> entity);
        T Update(T entity);
        T Update(T entity, params string[] fieldsToUpdate);
        T Update(T entity, bool cascade = false);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
    }
}
