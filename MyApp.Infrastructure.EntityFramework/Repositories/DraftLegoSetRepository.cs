using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework.Repositories
{
    public class DraftLegoSetRepository : IDraftLegoSetRepository
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public DraftLegoSetRepository(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(DraftLegoSet draft)
        {
            _unitOfWork.Set<DraftLegoSet>().Add(draft);
        }


        public void Remove(DraftLegoSet draft)
        {
            _unitOfWork.Set<DraftLegoSet>().Remove(draft);
        }

        public DraftLegoSet GetById(Guid id)
        {
            return _unitOfWork.Set<DraftLegoSet>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DraftLegoSet> GetAll()
        {
            return _unitOfWork.Set<DraftLegoSet>().ToList();
        }

        public DraftLegoSet GetDraftForLegoSet(Guid legoSetId)
        {
            return _unitOfWork.Set<DraftLegoSet>().FirstOrDefault(x => x.OriginalLegoSetId == legoSetId);
        }
    }
}
