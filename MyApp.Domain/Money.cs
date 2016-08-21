using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class Money
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }

        public Money()
        {
        }

        public Money(int amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
