using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    class Money<TCurrency> where TCurrency : ICurrency
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static Money<TCurrency> operator +(Money<TCurrency> m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            if (m1.GetType() != m2.GetType())
                throw new InvalidOperationException("Cannot add different types of Money");
            return new Money<TCurrency>(m1.Amount + m2.Amount);
        }

        public static Money<TCurrency> operator -(Money<TCurrency> m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            if (m1.GetType() != m2.GetType())
                throw new InvalidOperationException("Cannot subtract different types of Money");
            return new Money<TCurrency>(m1.Amount - m2.Amount);
        }

        public static MultiCurrencyMoney operator +(MultiCurrencyMoney m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount + m2.ConvertTo<EUR>().Amount);
        }
        public static MultiCurrencyMoney operator -(MultiCurrencyMoney m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount - m2.ConvertTo<EUR>().Amount);
        }
        public static MultiCurrencyMoney operator +(Money<TCurrency> m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.ConvertTo<EUR>().Amount + m2.Amount);
        }
        public static MultiCurrencyMoney operator -(Money<TCurrency> m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.ConvertTo<EUR>().Amount - m2.Amount);
        }

        public Money<TTargetCurrency> ConvertTo<TTargetCurrency>() where TTargetCurrency : ICurrency
        {
            return new Money<TTargetCurrency>(Amount * TCurrency.ExchangeRateToEUR / TTargetCurrency.ExchangeRateToEUR);
        }

        public override string ToString()
        {
            return $"{TCurrency.Code} {Amount}";
        }
    }
}
