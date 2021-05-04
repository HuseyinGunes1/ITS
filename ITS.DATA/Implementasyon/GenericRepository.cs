using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Repository;
using ITS.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.DATA.Implementasyon
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbset;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<TEntity>();

        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);//memory e kaydeder
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _dbset.ToListAsync();
        }
        public IEnumerable<CreateIsciBilgiDto> GetAllJoin(int id,bool durumu)
        {
            IEnumerable<CreateIsciBilgiDto> p =  ( from a in _dbContext.Set<Is>()
                     join v in _dbContext.Set<IsIsci>() on a.IsId equals v.IsId
                     join ka in _dbContext.Set<Isveren>() on a.IsverenId equals ka.IsverenId
                     where v.IsciId== id && v.Durumu == durumu
                     orderby a.Tarih descending

                     select new CreateIsciBilgiDto
                     {
                        IsAdi= a.IsAdi,
                        Tarih= a.Tarih,
                        Durumu= v.Durumu,
                        IsverenAdi= ka.IsverenAdi,
                        IsverenSoyadi= ka.IsverenSoyadi

                     }).ToList();

            

            return p;

                         
                         
        }

        public int GetAllToplamJoin(int id, bool durumu)
        {
            IEnumerable<CreateIsciBilgiDto> p = (from a in _dbContext.Set<Is>()
                                                 join v in _dbContext.Set<IsIsci>() on a.IsId equals v.IsId
                                                 join ka in _dbContext.Set<Isveren>() on a.IsverenId equals ka.IsverenId
                                                 where v.IsciId == id && v.Durumu == durumu
                                                 orderby a.Tarih descending

                                                 select new CreateIsciBilgiDto
                                                 {
                                                     IsAdi = a.IsAdi,
                                                     Tarih = a.Tarih,
                                                     Durumu = v.Durumu,
                                                     IsverenAdi = ka.IsverenAdi,
                                                     IsverenSoyadi = ka.IsverenSoyadi

                                                 }).ToList();

          int Toplam= p.Count();

            return Toplam;



        }


        public async Task<TEntity> GetAllByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

       
    }
}
