using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    class BGN : ICurrency
    {
        public static string Name => "лев";
        public static string Code => "BGN";
        public static decimal ExchangeRateToEUR => 0.51m;
    }
    class USD : ICurrency
    {
        public static string Name => "долар";
        public static string Code => "USD";
        public static decimal ExchangeRateToEUR => 0.88m;

    }
    class EUR : ICurrency
    {
        public static string Name => "евро";
        public static string Code => "EUR";
        public static decimal ExchangeRateToEUR => 1.0m;
    }
}