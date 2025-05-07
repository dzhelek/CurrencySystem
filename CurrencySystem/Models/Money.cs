using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    public class Money<TCurrency> : IMoney where TCurrency : ICurrency
    {
        private readonly decimal _amount;

        internal decimal Amount => _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public static Money<TCurrency> operator +(Money<TCurrency> m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            if (m1.GetType() != m2.GetType())
                throw new InvalidOperationException("Cannot add different types of Money");
            return new Money<TCurrency>(m1._amount + m2._amount);
        }

        public static Money<TCurrency> operator -(Money<TCurrency> m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            if (m1.GetType() != m2.GetType())
                throw new InvalidOperationException("Cannot subtract different types of Money");
            return new Money<TCurrency>(m1._amount - m2._amount);
        }

        public static MultiCurrencyMoney operator +(MultiCurrencyMoney m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount + m2.ConvertTo<EUR>()._amount);
        }
        public static MultiCurrencyMoney operator -(MultiCurrencyMoney m1, Money<TCurrency> m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.Amount - m2.ConvertTo<EUR>()._amount);
        }
        public static MultiCurrencyMoney operator +(Money<TCurrency> m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.ConvertTo<EUR>()._amount + m2.Amount);
        }
        public static MultiCurrencyMoney operator -(Money<TCurrency> m1, MultiCurrencyMoney m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Money cannot be null");
            return new MultiCurrencyMoney(m1.ConvertTo<EUR>()._amount - m2.Amount);
        }

        public Money<TTargetCurrency> ConvertTo<TTargetCurrency>() where TTargetCurrency : ICurrency
        {
            return new Money<TTargetCurrency>(_amount * TCurrency.ExchangeRateToEUR / TTargetCurrency.ExchangeRateToEUR);
        }

        public string ToStorageString()
        {
            return $"{_amount}|{TCurrency.Code}";
        }

        public static Money<TCurrency> FromStorageString(string storageString)
        {
            var parts = storageString.Split('|');
            if (parts.Length != 2 || !decimal.TryParse(parts[0], out decimal amount) || parts[1] != TCurrency.Code)
            {
                throw new ArgumentException($"Invalid storage string format or currency mismatch: {storageString}");
            }
            return new Money<TCurrency>(amount);
        }

        public override string ToString()
        {
            return $"{TCurrency.Symbol} {_amount:0.00}";
        }
    }
}
