using CotacaoDolar.Models;
using CotacaoDolar.ViewModels;

namespace CotacaoDolar;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
    }

    async void GetExchangeButtonClicked(System.Object sender, System.EventArgs e)
    {
        var svc = new ExchangeRateService();
        var exc = await svc.GetAsync();
        BuyLabel.Text = $"Valor de Compra: {exc.Value[0].Buy.ToString("C")}";
        SellLabel.Text = $"Valor de Venda: {exc.Value[0].Sell.ToString("C")}";
    }
}


