using CurrencySystem.Views;

namespace CurrencySystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("addproduct", typeof(AddProductPage));
        }
    }
}
