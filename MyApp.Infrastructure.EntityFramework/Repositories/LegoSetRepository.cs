using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework.Repositories
{
    public class LegoSetRepository : ILegoSetRepository
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public LegoSetRepository(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(LegoSet legoSet)
        {
            _unitOfWork.Set<LegoSet>().Add(legoSet);
        }

        public LegoSet GetById(Guid id)
        {
            return _unitOfWork.Set<LegoSet>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<LegoSet> GetAll()
        {
            return _unitOfWork.Set<LegoSet>().ToList();
        }
    }
}
