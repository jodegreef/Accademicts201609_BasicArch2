using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public interface IEFUnitOfWork : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;
    }
}
