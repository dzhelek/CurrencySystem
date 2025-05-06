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
                _ => throw new ArgumentException($"Unsupported currency code: {currencyCode}")
            };
        }

        public static string GetCurrencySymbol(string currencyCode)
        {
            return currencyCode.ToUpper() switch
            {
                "EUR" => "€",
                "USD" => "$",
                "GBP" => "£",
                _ => currencyCode
            };
        }
    }
}
