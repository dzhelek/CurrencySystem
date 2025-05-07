using SQLite;

namespace CurrencySystem.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique, NotNull]
        public string Name { get; set; }
        [NotNull]
        public int Quantity { get; set; }
        [NotNull]
        [Column("MoneyValue")]
        public string StoredMoneyValue { get; set; } = "0|EUR";

        [Ignore]
        public IMoney MoneyPrice
        {
            get
            {
                if (string.IsNullOrEmpty(StoredMoneyValue))
                {
                    StoredMoneyValue = "0|EUR";
                }

                var parts = StoredMoneyValue.Split('|');
                if (parts.Length != 2 || !decimal.TryParse(parts[0], out decimal amount))
                {
                    throw new ArgumentException($"Invalid money value format: {StoredMoneyValue}");
                }

                return CurrencyFactory.CreateMoney(amount, parts[1]);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                var storageString = value.ToStorageString();
                StoredMoneyValue = storageString;
            }
        }
    }
}
