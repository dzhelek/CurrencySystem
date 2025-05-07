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
            var total = new MultiCurrencyMoney(0);
            foreach (var product in Products)
            {
                total += product.Total;
            }
            TotalValue = total;
        }

        [RelayCommand]
        private async Task AddProduct()
        {
            await Shell.Current.GoToAsync("addproduct");
            await LoadProducts(); // Reload products when returning from add page
        }
    }
}
