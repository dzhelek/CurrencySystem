﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    interface ICurrency
    {
        public abstract static string Name { get; }
        public abstract static string Code { get; }
        public abstract static decimal ExchangeRateToEUR { get; }
    }
}
