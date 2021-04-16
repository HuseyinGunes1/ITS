using ITS.CORE.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.DATA.Implementasyon
{
    public class UnitOfWork : IUnirOfWork
    {
        private readonly DbContext _dbContext;
     
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
          

        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
