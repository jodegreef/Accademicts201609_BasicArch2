using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class DraftLegoSetFactory : IDraftLegoSetFactory
    {
        private IDraftLegoSetRepository _draftLegoSetRepository;
        private ILegoSetRepository _legoSetRepository;

        public DraftLegoSetFactory(
            IDraftLegoSetRepository draftLegoSetRepository,
            ILegoSetRepository legoSetRepository
            )
        {
            _draftLegoSetRepository = draftLegoSetRepository;
            _legoSetRepository = legoSetRepository;
        }

        public Guid CreateNewDraftForExistingSet(Guid legoSetId)
        {
            var existingDraft = _draftLegoSetRepository.GetDraftForLegoSet(legoSetId);
            if (existingDraft != null)
            {
                return existingDraft.Id;
            }
            else
            {
                var legoSet = _legoSetRepository.GetById(legoSetId);

                var draft = new DraftLegoSet(legoSet);

                _draftLegoSetRepository.Add(draft);

                return draft.Id;
            }
        }
    }
}
