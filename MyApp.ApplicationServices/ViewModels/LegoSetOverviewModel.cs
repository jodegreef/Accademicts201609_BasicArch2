using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationServices.ViewModels
{
    public class LegoSetOverviewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Currency Currency { get; set; }
        public bool IsSold { get; set; }
    }
}
