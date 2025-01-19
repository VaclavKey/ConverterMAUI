using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMAUI
{
    internal class ConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double SafeAreaTop { get; set; }
        public double SafeAreaBottom { get; set; }

        public double CurrencyBtnWidth { get; }
        public double CurrencyEntryWidth { get; }
        public double CurrencyImageSize { get; }
        public double CurrencyFieldHeight { get; }
        public double CalculatorHeight { get; }


        public static string FromCurrencyImg { get; set; }
        public static string FromCurrencyAbbr { get; set; }

        private string toCurrencyImg;
        private string toCurrencyAbbr;
        private string fromAmount;
        private string toAmount;


        public string ToCurrencyImg
        {
            get => toCurrencyImg;
            set
            {
                if (toCurrencyAbbr != value)
                {
                    toCurrencyImg = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToCurrencyImg"));
                }
            }
        }
        public string ToCurrencyAbbr
        {
            get => toCurrencyAbbr;
            set
            {
                if (toCurrencyAbbr != value)
                {
                    toCurrencyAbbr = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToCurrencyAbbr"));
                }
            }
        }
        public string FromAmount
        {
            get => fromAmount;
            set
            {
                if (fromAmount != value)
                {
                    fromAmount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FromAmount"));
                }
            }
        }
        public string ToAmount
        {
            get => toAmount;
            set
            {
                if (toAmount != value)
                {
                    toAmount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToAmount"));
                }
            }
        }

        public ConverterViewModel()
        {
            double screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double totalScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            double screenHeight = totalScreenHeight - SafeAreaTop - SafeAreaBottom;

            CurrencyBtnWidth = screenWidth * 0.2;
            CurrencyEntryWidth = screenWidth * 0.8;
            CurrencyImageSize = screenWidth * 0.1;
            CurrencyFieldHeight = screenHeight * 0.125;
            CalculatorHeight = screenHeight * 0.75;
        }
    }
}