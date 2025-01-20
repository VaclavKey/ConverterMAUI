using static ConverterMAUI.ConverterViewModel;
namespace ConverterMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        public void RUBClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "RUB";
            FromCurrencyImg = "rub.png";
            CurrencyClicked();
        }

        public void USDClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "USD";
            FromCurrencyImg = "usd.png";
            CurrencyClicked();
        }

        public void EURClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "EUR";
            FromCurrencyImg = "eur.png";
            CurrencyClicked();
        }

        public void GBPClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "GBP";
            FromCurrencyImg = "gbp.png";
            CurrencyClicked();
        }

        public void JPYClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "JPY";
            FromCurrencyImg = "jpy.png";
            CurrencyClicked();
        }

        public void BYNClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "BYN";
            FromCurrencyImg = "byn.png";
            CurrencyClicked();
        }

        public void PLNClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "PLN";
            FromCurrencyImg = "pln.png";
            CurrencyClicked();
        }

        public void CNYClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "CZY";
            FromCurrencyImg = "czy.png";
            CurrencyClicked();
        }

        public void TRYClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "TRYC";
            FromCurrencyImg = "tryc.png";
            CurrencyClicked();
        }

        public void KZTClicked(object sender, EventArgs e)
        {
            FromCurrencyAbbr = "KZT";
            FromCurrencyImg = "kzt.png";

            CurrencyClicked();
        }


        public async void CurrencyClicked()
        {
            await Navigation.PushAsync(new ConverterPage());
        }

        public void DisplayAlertClick(object sender, EventArgs e)
        {
            DisplayAlert("Кнопка нажата", "Вы нажали кнопку", "ОК");
        }
    }

}
