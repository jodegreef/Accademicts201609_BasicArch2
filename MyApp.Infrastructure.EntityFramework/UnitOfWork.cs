using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public class UnitOfWork : DbContext, IUnitOfWork, IEFUnitOfWork
    {

        private Guid id = Guid.NewGuid();
        private MyAppContext _context;

        public UnitOfWork(MyAppContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        IDbSet<T> IEFUnitOfWork.Set<T>()
        {
            return _context.Set<T>();
        }

    }
}
