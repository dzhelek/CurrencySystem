using CommunityToolkit.Mvvm.ComponentModel;
using CurrencySystem.Models;

namespace CurrencySystem.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly Product _product;

        public int Id => _product.Id;
        public string Name => _product.Name;
        public int Quantity => _product.Quantity;
        public IMoney Price => _product.MoneyPrice;
        public IMoney Total => CalculateTotal();
        public string FormattedTotal => Total.ToString();

        public ProductViewModel(Product product)
        {
            _product = product;
        }

        private IMoney CalculateTotal()
        {
            var price = _product.MoneyPrice;
            var parts = _product.StoredMoneyValue.Split('|');
            if (parts.Length != 2 || !decimal.TryParse(parts[0], out decimal amount))
            {
                throw new ArgumentException($"Invalid money value format: {_product.StoredMoneyValue}");
            }

            return CurrencyFactory.CreateMoney(amount * _product.Quantity, parts[1]);
        }
    }
} 