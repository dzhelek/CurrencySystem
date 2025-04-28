using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CurrencySystem.ViewModels
{
    internal partial class ProductsViewModel : ObservableObject
    {
        public ProductsViewModel()
        {
            // Initialize the view model
        }
        [RelayCommand]
        async Task AddProduct()
        {
            await Shell.Current.GoToAsync("addproduct");
        }
    }
}
