using chat.DATA.Context;
using chat.DATA.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DATA.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly chatContext _context;
        private bool disposed = false;
        DbContextTransaction transaction;

        public UnitofWork(chatContext context)
        {
            Database.SetInitializer<chatContext>(null);
            if (context == null)
            {
                throw new ArgumentException("Context is NULL");
            }
            _context = context;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }
        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
