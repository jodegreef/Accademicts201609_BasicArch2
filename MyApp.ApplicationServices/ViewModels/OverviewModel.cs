using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationServices.ViewModels
{
    public class OverviewModel
    {
        public IEnumerable<LegoSetOverviewModel> LegoSets { get; set; }
        public IEnumerable<DraftLegoSetOverviewModel> Drafts { get; set; }
    }
}
