using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; }
        public Currency(string name, string code, decimal exchangeRate)
        {
            Name = name;
            Code = code;
            ExchangeRate = exchangeRate;
        }
        public override string ToString()
        {
            return $"{Name} ({Code}) - Exchange Rate: {ExchangeRate}";
        }
    }
}
