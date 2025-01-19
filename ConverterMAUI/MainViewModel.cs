using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMAUI
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public static string currentCurrency { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

    }
}
