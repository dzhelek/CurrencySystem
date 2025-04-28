using CurrencySystem.ViewModels;

namespace CurrencySystem.Views;

public partial class AddProductPage : ContentPage
{
	public AddProductPage()
	{
		InitializeComponent();
        BindingContext = new AddProductViewModel();
    }
}