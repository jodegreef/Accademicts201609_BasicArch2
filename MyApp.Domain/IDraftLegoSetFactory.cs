using System;

namespace MyApp.Domain
{
    public interface IDraftLegoSetFactory
    {
        Guid CreateNewDraftForExistingSet(Guid legoSetId);
    }
}