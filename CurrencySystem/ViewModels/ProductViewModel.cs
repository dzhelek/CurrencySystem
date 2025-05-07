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
            if (price is Money<EUR> eurMoney)
            {
                return new Money<EUR>(eurMoney.Amount * _product.Quantity);
            }
            else if (price is Money<USD> usdMoney)
            {
                return new Money<USD>(usdMoney.Amount * _product.Quantity);
            }
            else if (price is Money<GBP> gbpMoney)
            {
                return new Money<GBP>(gbpMoney.Amount * _product.Quantity);
            }
            else if (price is MultiCurrencyMoney multiMoney)
            {
                return new MultiCurrencyMoney(multiMoney.Amount * _product.Quantity);
            }
            throw new ArgumentException($"Unsupported money type: {price.GetType()}");
        }
    }
} 