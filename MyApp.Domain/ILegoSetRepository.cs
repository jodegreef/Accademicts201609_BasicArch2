using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public interface ILegoSetRepository
    {
        LegoSet GetById(Guid id);

        IEnumerable<LegoSet> GetAll();

        void Add(LegoSet legoSet);
    }
}
