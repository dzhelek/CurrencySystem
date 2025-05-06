using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CurrencySystem.Models;
using System.Collections.ObjectModel;

namespace CurrencySystem.ViewModels
{
    [ObservableObject]
    internal partial class AddProductViewModel
    {
        private readonly ProductRepository _repository;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int quantity;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private string selectedCurrency = "EUR";

        public ObservableCollection<string> AvailableCurrencies { get; } = new()
        {
            "EUR",
            "USD",
            "GBP"
        };

        public AddProductViewModel(ProductRepository repository)
        {
            _repository = repository;
        }

        private IMoney CreateMoneyFromInput()
        {
            return SelectedCurrency switch
            {
                "EUR" => new Money<EUR>(Price),
                "USD" => new Money<USD>(Price),
                "GBP" => new Money<GBP>(Price),
                _ => throw new ArgumentException($"Unsupported currency: {SelectedCurrency}")
            };
        }

        [RelayCommand]
        public async Task SaveProduct()
        {
            if (string.IsNullOrWhiteSpace(Name) || Price <= 0 || Quantity <= 0)
                return;

            var product = new Product
            {
                Name = Name,
                Quantity = Quantity,
                MoneyPrice = CreateMoneyFromInput()
            };

            await _repository.SaveProductAsync(product);
            await Shell.Current.GoToAsync("..");
        }
    }
}
