using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class LegoSetPublisherDomainService : ILegoSetPublisherDomainService
    {
        private IDraftLegoSetRepository _draftLegoSetRepository;
        private ILegoSetRepository _legoSetRepository;

        public LegoSetPublisherDomainService(
            IDraftLegoSetRepository draftLegoSetRepository,
            ILegoSetRepository legoSetRepository
            )
        {
            _draftLegoSetRepository = draftLegoSetRepository;
            _legoSetRepository = legoSetRepository;
        }

        public void Publish(Guid draftLegoSetId)
        {
            var draft = _draftLegoSetRepository.GetById(draftLegoSetId);

            if (draft.IsNewDraft)
            {
                var legoSet = new LegoSet();
                legoSet.TakeValuesFromDraft(draft);
                _legoSetRepository.Add(legoSet);
            }
            else
            {
                var legoSet = _legoSetRepository.GetById(draft.OriginalLegoSetId.Value);
                legoSet.TakeValuesFromDraft(draft);
            }

            _draftLegoSetRepository.Remove(draft);
        }
    }
}
