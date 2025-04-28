using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    class CurrencyFactory
    {
        public static ICurrency CreateCurrency(string code)
        {
            return code switch
            {
                "BGN" => new BGN(),
                "USD" => new USD(),
                "EUR" => new EUR(),
                _ => throw new ArgumentException($"Invalid currency code: {code}")
            };
        }
    }
}
