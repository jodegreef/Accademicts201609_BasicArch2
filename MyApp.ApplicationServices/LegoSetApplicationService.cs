using MyApp.ApplicationServices.ViewModels;
using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationServices
{
    public class LegoSetApplicationService
    {
        private ILegoSetRepository _legoSetRepository;
        private IDraftLegoSetRepository _draftLegoSetRepository;

        public LegoSetApplicationService(
            ILegoSetRepository legoSetRepository,
            IDraftLegoSetRepository draftLegoSetRepository
            )
        {
            _legoSetRepository = legoSetRepository;
            _draftLegoSetRepository = draftLegoSetRepository;
        }

        public OverviewModel GetOverview()
        {
            var legoSets = _legoSetRepository.GetAll()
                .Select(x => new LegoSetOverviewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price.Amount,
                    Currency = x.Price.Currency,
                    IsSold = x.IsSold
                }).ToList();

            var drafts = _draftLegoSetRepository.GetAll()
                .Select(x => new DraftLegoSetOverviewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return new OverviewModel
            {
                LegoSets = legoSets,
                Drafts = drafts
            };
        }
    }
}
