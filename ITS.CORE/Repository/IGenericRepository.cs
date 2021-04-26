using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Repository
{
   public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAllByIdAsync(int id);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        

        decimal WhereToplam(Expression<Func<TEntity,decimal>> predicate);
        TEntity Update(TEntity entity);
    }
}
