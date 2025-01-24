using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMAUI
{
    internal class ConverterListViewModel : INotifyPropertyChanged
    {
        //private async Task SetAmounts()
        //{
        //    foreach (var key in amounts.Keys.ToList())
        //    {
        //        amounts[key] = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, key);
        //    }
        //    TRYAmount = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "TRY");
        //}

        private decimal? amountRUB;
        public decimal? AmountRUB
        {
            get => amountRUB;
            set
            {
                if (amountRUB != value)
                {
                    amountRUB = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountRUB"));
                }
            }
        }
        private decimal? amountUSD;
        public decimal? AmountUSD
        {
            get => amountUSD;
            set
            {
                if (amountUSD != value)
                {
                    amountUSD = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountUSD"));
                }
            }
        }
        private decimal? amountEUR;
        public decimal? AmountEUR
        {
            get => amountEUR;
            set
            {
                if (amountEUR != value)
                {
                    amountEUR = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountEUR"));
                }
            }
        }
        private decimal? amountGBP;
        public decimal? AmountGBP
        {
            get => amountGBP;
            set
            {
                if (amountGBP != value)
                {
                    amountGBP = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountGBP"));
                }
            }
        }
        private decimal? amountJPY;
        public decimal? AmountJPY
        {
            get => amountJPY;
            set
            {
                if (amountJPY != value)
                {
                    amountJPY = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountJPY"));
                }
            }
        }
        private decimal? amountBYN;
        public decimal? AmountBYN
        {
            get => amountBYN;
            set
            {
                if (amountBYN != value)
                {
                    amountBYN = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountBYN"));
                }
            }
        }
        private decimal? amountPLN;
        public decimal? AmountPLN
        {
            get => amountPLN;
            set
            {
                if (amountPLN != value)
                {
                    amountPLN = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountPLN"));
                }
            }
        }
        private decimal? amountCNY;
        public decimal? AmountCNY
        {
            get => amountCNY;
            set
            {
                if (amountCNY != value)
                {
                    amountCNY = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountCNY"));
                }
            }
        }
        private decimal? amountTRY;
        public decimal? AmountTRY
        {
            get => amountTRY;
            set
            {
                if (amountTRY != value)
                {
                    amountTRY = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountTRY"));
                }
            }
        }
        private decimal? amountKZT;
        public decimal? AmountKZT
        {
            get => amountKZT;
            set
            {
                if (amountKZT != value)
                {
                    amountKZT = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountKZT"));
                }
            }
        }













        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> Currencies { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public double CurrencyBtnWidth { get; }
        public double CurrencyEntryWidth { get; }
        public double CurrencyImgSize { get; }
        public double CurrencyFieldHeight { get; }
        public double AbbrZoneWidth { get; }
        public double AmountZoneWidth { get; }
        public double CurrencyChoiceFieldHeight { get; }
        public double MainCurrencyImgSize { get; }

        private string mainCurrencyImg;
        public string MainCurrencyImg
        {
            get => mainCurrencyImg;
            set
            {
                if (mainCurrencyImg != value)
                {
                    mainCurrencyImg = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainCurrencyImg"));

                }
            }
        }

        public static string FromCurrencyImg { get; set; }

        private string fromCurrencyAbbr;
        public string FromCurrencyAbbr
        {
            get => fromCurrencyAbbr;
            set
            {
                if (fromCurrencyAbbr != value)
                {
                    fromCurrencyAbbr = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FromCurencyAbbr"));
                    MainCurrencyImg = FromCurrencyAbbr.ToLower() + ".png";
                }
            }
        }

        private decimal? fromAmount;

        public string FromCurrencyCheck { get; set; }
        public string ToCurrencyCheck { get; set; }
        public decimal? FromAmount
        {
            get => fromAmount;
            set
            {
                if (fromAmount != value)
                {
                    fromAmount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FromAmount"));
                    _ = RunLoadDataAsync();
                }
            }
        }

        public ConverterListViewModel()
        {
            Currencies = new ObservableCollection<string>
            {
                "RUB",
                "USD",
                "EUR",
                "GBP",
                "JPY",
                "BYN",
                "PLN",
                "CNY",
                "TRY",
                "KZT"
            };

            FromCurrencyCheck = FromCurrencyAbbr;

            double screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            CurrencyBtnWidth = screenWidth * 0.3;
            CurrencyChoiceFieldHeight = screenWidth * 0.3;
            CurrencyEntryWidth = screenWidth * 0.6;
            CurrencyImgSize = screenWidth * 0.12;
            MainCurrencyImgSize = screenWidth * 0.15;
            AbbrZoneWidth = screenWidth * 0.3;
            AmountZoneWidth = screenWidth * 0.7;
            CurrencyFieldHeight = screenHeight * 0.08;
        }

        private async Task RunLoadDataAsync()
        {
            await Convert();
        }
        private async Task Convert()
        {
            AmountRUB = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "RUB");
            AmountUSD = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "USD");
            AmountEUR = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "EUR");
            AmountGBP = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "GBP");
            AmountJPY = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "JPY");
            AmountBYN = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "BYN");
            AmountPLN = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "PLN");
            AmountCNY = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "CNY");
            AmountTRY = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "TRY");
            AmountKZT = FromAmount * await CurrencyConverter.GetRate(FromCurrencyAbbr, "KZT");

        }

    }
}
