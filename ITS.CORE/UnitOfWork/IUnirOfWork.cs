using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.UnitOfWork
{
   public interface IUnirOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
