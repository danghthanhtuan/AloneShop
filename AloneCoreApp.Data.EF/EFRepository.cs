using AloneCoreApp.Infrastructure.Interfaces;
using AloneCoreApp.Infrastructure.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Data.EF
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntities<K>
    {
        private readonly AppDbContext _context;
        public EFRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public virtual async Task<T> FindByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await FindAll(includeProperties).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).FirstOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await FindAll(includeProperties).SingleOrDefaultAsync(predicate);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
