using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    public static class CurrencyFactory
    {
        public static IMoney CreateMoney(decimal amount, string currencyCode)
        {
            return currencyCode.ToUpper() switch
            {
                "EUR" => new Money<EUR>(amount),
                "USD" => new Money<USD>(amount),
                "GBP" => new Money<GBP>(amount),
                "BGN" => new Money<BGN>(amount),
                _ => throw new ArgumentException($"Unsupported currency code: {currencyCode}")
            };
        }
    }
}
