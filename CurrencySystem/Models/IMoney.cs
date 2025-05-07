using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    public interface IMoney
    {
        Money<TCurrency> ConvertTo<TCurrency>() where TCurrency : ICurrency;
        string ToStorageString();
    }
}
