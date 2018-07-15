using JoseBeloDelfino.Data.Contexto;
using JoseBeloDelfino.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace JoseBeloDelfino.Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T>, IDisposable where T : class
    {
        protected JoseBeloDelfinoDbContexto context;
        //private DbSet<T> entity;

        public RepositorioBase()
        {
            context = new JoseBeloDelfinoDbContexto();
        }

        public bool Any()
        {
            return context.Set<T>().Any();
        }

        public bool Any(Expression<Func<T, bool>> expression = null)
        {
            return context.Set<T>().Any(expression);
        }

        public int Count()
        {
            return context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> expression = null)
        {
            return context.Set<T>().Count(expression);
        }

        public IQueryable<T> Select(params string[] includes)
        {
            var query = context.Set<T>().AsQueryable();

            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = context.Set<T>().AsQueryable();

            if (includes.Any())
            {
                if (expression != null)
                {
                    query = includes.Aggregate(query.Where(expression), (current, include) => current.Include(include));
                }
                else
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }
            }
            else
            {
                if (expression != null)
                {
                    query = query.Where(expression);
                }
            }

            return query;
        }

        public T Insert(T entity)
        {
            T retorno = context.Set<T>().Add(entity);
            context.SaveChanges();

            return retorno;
        }

        public IEnumerable<T> Insert(IEnumerable<T> entity)
        {
            IEnumerable<T> retorno = context.Set<T>().AddRange(entity);
            context.SaveChanges();

            return retorno;
        }

        public T Update(T entity)
        {
            T retorno = context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();

            return retorno;
        }

        public T Update(T entity, params string[] fieldsToUpdate)
        {
            context.Entry(entity).State = EntityState.Modified;

            Type tipo = entity.GetType();
            IList<string> listFieldsToUpdate = fieldsToUpdate.ToList();

            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                if (listFieldsToUpdate.Any(p => p == prop.Name))
                {
                    context.Entry(entity).Property(prop.Name).IsModified = true;
                    listFieldsToUpdate.Remove(prop.Name);
                    continue;
                }

                if (!prop.CustomAttributes.Any(c => c.AttributeType.Name == "KeyAttribute") &&
                    !prop.CustomAttributes.Any(c => c.AttributeType.Name == "NotMappedAttribute") &&
                    prop.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) == null)
                {
                    context.Entry(entity).Property(prop.Name).IsModified = false;
                }
            }

            context.SaveChanges();

            return entity;
        }

        public T Update(T entity, bool cascade = false)
        {
            context.Entry(entity).State = EntityState.Modified;

            if (cascade)
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    var a = item.GetValue(entity);
                    if (item.PropertyType.IsClass && Attribute.IsDefined(item.PropertyType, typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute)) && a != null)
                    {
                        Type tipo = Assembly.GetAssembly(item.PropertyType).GetType(item.PropertyType.FullName);
                        context.Entry(a).State = EntityState.Modified;
                    }
                }
            }

            context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            context.Set<T>().RemoveRange(context.Set<T>().Where(expression));
            context.SaveChanges();
        }

        #region Disposable
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (context != null) context.Dispose();
                }
                context = null;
                _disposed = true;
            }
        }
        #endregion
    }
}
