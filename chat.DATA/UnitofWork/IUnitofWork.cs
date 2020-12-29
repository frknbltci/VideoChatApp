using chat.DATA.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DATA.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
