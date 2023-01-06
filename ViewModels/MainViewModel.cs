using CurrencyAPIWPF.Models;
using CurrencyAPIWPF.Views;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyAPIWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Currency> _exchnageCurrencys = new ObservableCollection<Currency>();
        public ICommand LoadExchangeCurrencyCommand { get; }

        public ICommand ConvertCurrenciesCommand { get; set; }

        public ObservableCollection<Currency> ExchangeCurrencys
        {
            get => _exchnageCurrencys;

            set
            {
                _exchnageCurrencys = value;
                OnPropertyChanged();
            }
        }


        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            ExchangeCurrencys = new ObservableCollection<Currency>();
            ConvertCurrenciesCommand = new RelayCommand(OpenConvertCurrenciesWindow);
            LoadExchangeCurrencyCommand = new RelayCommand(async () => await LoadExchangeCurrencyAsync());

        }

        public async Task LoadExchangeCurrencyAsync()
        {
            IsLoading = true;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://api.nbp.pl/api/exchangerates/tables/c/?format=json");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var table = JsonConvert.DeserializeObject<List<ExchangeCurrency>>(content)[0];
                    List<Currency>? rates = table.rates;

                    ExchangeCurrencys.Clear();
                    foreach (var rate in rates)
                    {
                        ExchangeCurrencys.Add(rate);
                    }
                }
            }

            IsLoading = false;

        }


        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenConvertCurrenciesWindow()
        {
            var convertCurrenciesWindow = new ConvertCurrenciesWindow();
            convertCurrenciesWindow.Show();
        }

    }
}
