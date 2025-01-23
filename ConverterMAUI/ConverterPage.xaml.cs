using static ConverterMAUI.ConverterViewModel;
namespace ConverterMAUI;

public partial class ConverterPage : ContentPage
{
    public ConverterPage()
    {
        InitializeComponent();

        var viewModel = new ConverterViewModel
        {
        };

        fromCurrencyImg.Source = FromCurrencyImg;
        fromCurrencyAbbr.Text = FromCurrencyAbbr;
        //toCurrencyImg.Source = "usd.png";
        //toCurrencyAbbr.Text = "USD";
    }
}