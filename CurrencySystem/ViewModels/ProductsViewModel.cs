using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CurrencySystem.Models;
using System.Collections.ObjectModel;

namespace CurrencySystem.ViewModels
{
    [ObservableObject]
    internal partial class ProductsViewModel
    {
        private readonly ProductRepository _repository;

        [ObservableProperty]
        private ObservableCollection<ProductViewModel> products;

        [ObservableProperty]
        private MultiCurrencyMoney totalValue;

        public ProductsViewModel(ProductRepository repository)
        {
            _repository = repository;
            Products = new ObservableCollection<ProductViewModel>();
            LoadProductsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadProducts()
        {
            var loadedProducts = await _repository.GetAllProductsAsync();
            Products = new ObservableCollection<ProductViewModel>(
                loadedProducts.Select(p => new ProductViewModel(p))
            );
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal totalInEur = 0;
            foreach (var product in Products)
            {
                var total = product.Total;
                if (total is Money<EUR> eurMoney)
                {
                    totalInEur += eurMoney.Amount;
                }
                else if (total is Money<USD> usdMoney)
                {
                    totalInEur += usdMoney.ConvertTo<EUR>().Amount;
                }
                else if (total is Money<GBP> gbpMoney)
                {
                    totalInEur += gbpMoney.ConvertTo<EUR>().Amount;
                }
                else if (total is MultiCurrencyMoney multiMoney)
                {
                    totalInEur += multiMoney.Amount;
                }
            }
            TotalValue = new MultiCurrencyMoney(totalInEur);
        }

        [RelayCommand]
        private async Task AddProduct()
        {
            await Shell.Current.GoToAsync("addproduct");
            await LoadProducts(); // Reload products when returning from add page
        }
    }
}
