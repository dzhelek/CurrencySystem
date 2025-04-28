using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    internal class MoneyDTO
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public MoneyDTO(decimal amount, string currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }
        public MoneyDTO() { }
        public override string ToString()
        {
            return $"{Amount} {CurrencyCode}";
        }

        //public Money<IMoney> ToMoney()
        //{
        //    var currency = CurrencyFactory.CreateCurrency(CurrencyCode);
        //    return new Money<IMoney>(Amount, currency);
        //}
    }
}
