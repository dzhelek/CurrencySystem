﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    class MultiCurrencyMoney
    {
        public decimal Amount { get; }
        public MultiCurrencyMoney(decimal amount=0)
        {
            Amount = amount;
        }

        public static MultiCurrencyMoney operator +(MultiCurrencyMoney m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount + m2.Amount);
        }
        public static MultiCurrencyMoney operator -(MultiCurrencyMoney m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount - m2.Amount);
        }

        public Money<TTargetCurrency> ConvertTo<TTargetCurrency>() where TTargetCurrency : ICurrency
        {
            return new Money<TTargetCurrency>(Amount / TTargetCurrency.ExchangeRateToEUR);
        }

        public override string ToString()
        {
            return $"EUR {Amount}";
        }

    }
}
