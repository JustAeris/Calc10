using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Currency.xaml
    /// </summary>
    public partial class Currency : UserControl
    {
        public Currency()
        {
            InitializeComponent();
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string[] availableCurrency = CurrencyConverterClass.GetCurrencyTags();
            foreach (var currency in availableCurrency)
            {
                CurrencyListFROM.Items.Add(currency.ToUpper());
                CurrencyListTO.Items.Add(currency.ToUpper());
            }
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            float amount = 1;
            string fromCurrency, toCurrency;
            bool reverseEUR;

            if (Convert.ToString(CurrencyListTO.SelectedItem) == "EUR")
            {
                fromCurrency = Convert.ToString(CurrencyListTO.SelectedItem);
                toCurrency = Convert.ToString(CurrencyListFROM.SelectedItem);
                reverseEUR = true;
            }
            else
            {
                fromCurrency = Convert.ToString(CurrencyListFROM.SelectedItem);
                toCurrency = Convert.ToString(CurrencyListTO.SelectedItem);
                reverseEUR = false;
            }


            if (!string.IsNullOrEmpty(CurrencyAmountTextBox.Text))
                try { amount = Convert.ToSingle(CurrencyAmountTextBox.Text); }
                catch
                {
                    MessageBox.Show("A fatal error has occured !", "Oops !", MessageBoxButton.OK, MessageBoxImage.Error);
                    CurrencyAmountTextBox.Text = "";
                }


            if (fromCurrency == "EUR" || toCurrency == "EUR")
            {
                float exchangeRate = CurrencyConverterClass.GetCurrencyRateInEuro(toCurrency);
                if (reverseEUR == false)
                    exchangeRate = exchangeRate * amount;
                else if (reverseEUR == true)
                    exchangeRate = (1 / exchangeRate) * amount;

                ConvertResultTextBox.Text = Convert.ToString(exchangeRate);
            }
            else
            {
                float exchangeRate = CurrencyConverterClass.GetExchangeRate(fromCurrency, toCurrency, Convert.ToSingle(amount));
                ConvertResultTextBox.Text = Convert.ToString(exchangeRate);
            }
            

        }
    }
}
