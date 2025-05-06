using CurrencySystem.Models;
using CurrencySystem.ViewModels;
using System.Diagnostics;

namespace CurrencySystem
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ProductsViewModel(App.ProductRepo);

            var m1 = new Money<BGN>(17.5m);
            var m2 = new Money<EUR>(25);
            var m3 = new Money<BGN>(10);

            //var m8 = new Money<ICurrency>(15);

            var m4 = m1.ConvertTo<USD>();
            var m5 = new MultiCurrencyMoney();
            var m6 = m5 + m1;

            var m7 = m1 + m5;

            Trace.WriteLine("hello");
            //Trace.WriteLine(m1 + m2);
            Trace.WriteLine(m1 - m3);
            Trace.WriteLine(m4);
            Trace.WriteLine(m7);
            Trace.WriteLine(m7.ConvertTo<USD>());

        }

        private void OnConvertButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnSubmitFeedbackButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnHelpButtonClicked(object sender, EventArgs e)
        {

        }
    }

}
