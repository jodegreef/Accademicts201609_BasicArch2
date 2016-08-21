using System;

namespace MyApp.Domain
{
    public interface ILegoSetPublisherDomainService
    {
        void Publish(Guid draftLegoSetId);
    }
}