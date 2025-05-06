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
        private ObservableCollection<Product> products;

        public ProductsViewModel(ProductRepository repository)
        {
            _repository = repository;
            Products = new ObservableCollection<Product>();
            LoadProductsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadProducts()
        {
            var loadedProducts = await _repository.GetAllProductsAsync();
            Products = new ObservableCollection<Product>(loadedProducts);
        }

        [RelayCommand]
        private async Task AddProduct()
        {
            await Shell.Current.GoToAsync("addproduct");
            await LoadProducts(); // Reload products when returning from add page
        }
    }
}
