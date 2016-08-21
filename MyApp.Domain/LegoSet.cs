using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class LegoSet : Entity
    {
        public string Name { get; protected set; }
        public Money Price { get; protected set; }
        public bool IsSold { get; protected set; }
        public bool IsMint { get; protected set; }

        public void TakeValuesFromDraft(DraftLegoSet draft)
        {
            Name = draft.Name;
            Price = draft.Price;
            IsSold = draft.IsSold.GetValueOrDefault();
            IsMint = draft.IsMint.GetValueOrDefault();
        }
    }
}
