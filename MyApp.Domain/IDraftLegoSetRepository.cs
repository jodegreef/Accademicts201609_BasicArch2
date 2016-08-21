using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public interface IDraftLegoSetRepository
    {
        DraftLegoSet GetById(Guid id);

        IEnumerable<DraftLegoSet> GetAll();

        void Add(DraftLegoSet draft);

        void Remove(DraftLegoSet draft);
        DraftLegoSet GetDraftForLegoSet(Guid legoSetId);
    }
}
