using MyApp.ApplicationServices.ViewModels;
using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationServices
{
    public class DraftLegoSetApplicationService
    {
        private IUnitOfWork _uow;
        private ILegoSetRepository _legoSetRepository;
        private IDraftLegoSetRepository _draftLegoSetRepository;
        private IDraftLegoSetFactory _draftLegoSetFactory;
        private ILegoSetPublisherDomainService _legoSetPublisherDomainService;

        public DraftLegoSetApplicationService(
            IUnitOfWork uow,
            ILegoSetRepository legoSetRepository, 
            IDraftLegoSetRepository draftLegoSetRepository,
            IDraftLegoSetFactory draftLegoSetFactory,
            ILegoSetPublisherDomainService legoSetPublisherDomainService
            )
        {
            _uow = uow;
            _legoSetRepository = legoSetRepository;
            _draftLegoSetRepository = draftLegoSetRepository;
            _draftLegoSetFactory = draftLegoSetFactory;
            _legoSetPublisherDomainService = legoSetPublisherDomainService;
        }


        public DraftLegoSet GetDraft(Guid id)
        {
            return _draftLegoSetRepository.GetById(id);
        }

        public Guid CreateNewDraft()
        {
            var draft = new DraftLegoSet();

            _draftLegoSetRepository.Add(draft);

            _uow.Commit();

            return draft.Id;
        }

        public Guid CreateNewDraftForExistingSet(Guid legoSetId)
        {
            var draftId = _draftLegoSetFactory.CreateNewDraftForExistingSet(legoSetId);

            _uow.Commit();

            return draftId;
        }

        public void SaveDraft(DraftLegoSet input)
        {
            var draft = _draftLegoSetRepository.GetById(input.Id);

            draft.Name = input.Name;
            draft.Price = input.Price;
            draft.IsMint = input.IsMint;
            draft.Price = input.Price ?? new Money();

            _uow.Commit();
        }


        public void Publish(Guid draftId)
        {
            _legoSetPublisherDomainService.Publish(draftId);
            
            //do other things like for example sending a notification email to someone

            _uow.Commit();
        }
    }
}
