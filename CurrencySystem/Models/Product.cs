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
        public IMoney Price { get; set; }
        //public Money<EUR> Price { get; set; }
        //[MaxLength(3), NotNull]
        //public string Currency { get; set; }
    }
}
