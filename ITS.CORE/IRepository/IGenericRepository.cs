using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.IRepository
{
   public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task AddAsync(TEntity entity);
        void Remove(int id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllByIdAsync(int id);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        double WhereUcret(Expression<Func<TEntity, bool>> predicate);
        TEntity Update(TEntity entity);
    }
}
