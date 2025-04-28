using CurrencySystem.Models;
using CurrencySystem.Helpers;

namespace CurrencySystem
{
    public partial class App : Application
    {
        public static ProductRepository ProductRepo { get; private set; }
        public App()
        {
            InitializeComponent();
            ProductRepo = new ProductRepository(FileAccessHelper.GetLocalFilePath("testing.db3"));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            ProductRepo.Init().ContinueWith((s) => { } );

            return new Window(new AppShell());
        }
    }
}