using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class DraftLegoSet : Entity
    {
        public Guid? OriginalLegoSetId { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
        public bool? IsSold { get; set; }
        public bool? IsMint { get; set; }

        public bool IsNewDraft
        {
            get
            {
                return !OriginalLegoSetId.HasValue;
            }
        }

        public DraftLegoSet()
        {

        }

        public DraftLegoSet(LegoSet original)
        {
            OriginalLegoSetId = original.Id;
            Name = original.Name;
            Price = original.Price;
            IsSold = original.IsSold;
            IsMint = original.IsMint;
        }
    }
}
