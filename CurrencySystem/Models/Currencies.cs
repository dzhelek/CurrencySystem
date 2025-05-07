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
        public static string Symbol => "лв.";
    }
    public class EUR : ICurrency
    {
        public static string Name => "Euro";
        public static string Code => "EUR";
        public static decimal ExchangeRateToEUR => 1.0m;
        public static string Symbol => "€";
    }
    public class USD : ICurrency
    {
        public static string Name => "US Dollar";
        public static string Code => "USD";
        public static decimal ExchangeRateToEUR => 0.88m;
        public static string Symbol => "$";
    }
    public class GBP : ICurrency
    {
        public static string Name => "British Pound";
        public static string Code => "GBP";
        public static decimal ExchangeRateToEUR => 1.17m;
        public static string Symbol => "£";
    }
}