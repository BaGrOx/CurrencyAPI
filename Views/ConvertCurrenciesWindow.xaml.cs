using CurrencyAPIWPF.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace CurrencyAPIWPF.Views
{
    /// <summary>
    /// Interaction logic for ConvertCurrenciesWindow.xaml
    /// </summary>
    public partial class ConvertCurrenciesWindow : Window
    {
        public ConvertCurrenciesWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void txtFromValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!double.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }
    }
}
