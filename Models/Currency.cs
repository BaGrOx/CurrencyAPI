using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPIWPF.Models
{
    public class Currency : INotifyPropertyChanged
    {
        private string? _currency;
        public string? currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                OnPropertyChanged();
            }
        }

        private string? _code;
        public string? code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        private decimal _ask;
        public decimal ask
        {
            get { return _ask; }
            set
            {
                _ask = value;
                OnPropertyChanged();
            }
        }

        private decimal _bid;
        public decimal bid
        {
            get { return _bid; }
            set
            {
                _bid = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

