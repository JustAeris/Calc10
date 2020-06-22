using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc10
{
    /// <summary>
    /// Logique d'interaction pour Programmer.xaml
    /// </summary>
    public partial class Programmer : System.Windows.Controls.UserControl
    {
        public Programmer()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(50);
            numberType.SelectedIndex = 0;
        }

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                DecimalResult.Text = "";
                HexadecimalResult.Text = "";
                OctalResult.Text = "";
                BinaryResult.Text = "";
            }

            long l = 0;
            string s = numberTextBox.Text;
            bool numOnly = Int64.TryParse(s, out l);

            try { long l2 = Int64.Parse(s, System.Globalization.NumberStyles.HexNumber); numOnly = true; }
            catch { numOnly = false; }

            if (numOnly == true)
            {
                string dec = "", hex = "", oct = "", bin = "";
                long n = 0;

                try 
                { 
                    if (numberType.SelectedIndex == 1)
                        n = Int64.Parse(s, System.Globalization.NumberStyles.HexNumber); 
                    else if (!string.IsNullOrEmpty(numberTextBox.Text))
                        n = Convert.ToInt64(numberTextBox.Text);
                }
                catch
                {
                }

               


                try
                {
                    if (!string.IsNullOrEmpty(numberTextBox.Text))
                    {
                        switch (numberType.SelectedIndex)
                        {
                            case (0):
                                dec = Convert.ToString(n);
                                hex = Convert.ToString(n, 16);
                                oct = Convert.ToString(n, 8);
                                bin = Convert.ToString(n, 2);
                                break;

                            case (1):
                                dec = Convert.ToString(n);
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(Convert.ToInt64(dec), 8);
                                bin = Convert.ToString(Convert.ToInt64(dec), 2);
                                break;

                            case (2):
                                dec = Convert.ToString(Convert.ToInt32(Convert.ToString(n), 8));
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(n);
                                bin = Convert.ToString(Convert.ToInt64(dec), 2);
                                break;

                            case (3):
                                dec = Convert.ToString(Convert.ToInt32(Convert.ToString(n), 2));
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(Convert.ToInt64(dec), 8);
                                bin = Convert.ToString(n);
                                break;
                        }
                    }
                    else
                    {
                        dec = "";
                        hex = "";
                        oct = "";
                        bin = "";
                    }
                    DecimalResult.Text = dec;
                    HexadecimalResult.Text = hex.ToUpper();
                    OctalResult.Text = oct;
                    BinaryResult.Text = bin;
                }
                catch
                {
                    DialogResult result = (DialogResult)System.Windows.MessageBox.Show($"Invalid Value !\nValue must not be higher than {Int64.MaxValue} Decimal\nAllowed Characters for each value :\nDecimal: 1 2 3 4 5 6 7 8 9 0\nHexadecimal : 1 2 3 4 5 6 7 8 9 0 A B C D E F\n /!\\ (Length must not exceed 6)\nOctal : 1 2 3 4 5 6 7 0\nBinary : 1 0\n\nClear TextBox ?", "Error",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == DialogResult.Yes)
                    {
                        numberTextBox.Text = "";
                        DecimalResult.Text = "";
                        HexadecimalResult.Text = "";
                        OctalResult.Text = "";
                        BinaryResult.Text = "";
                    }
                        
                }
            }
            else
                numberTextBox.Text = "";
        }

        private void numberType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                DecimalResult.Text = "";
                HexadecimalResult.Text = "";
                OctalResult.Text = "";
                BinaryResult.Text = "";
            }

            long l = 0;
            string s = numberTextBox.Text;
            bool numOnly = Int64.TryParse(s, out l);

            try { long l2 = Int64.Parse(s, System.Globalization.NumberStyles.HexNumber); numOnly = true; }
            catch { numOnly = false; }

            if (numOnly == true)
            {
                string dec = "", hex = "", oct = "", bin = "";
                long n = 0;

                try
                {
                    if (numberType.SelectedIndex == 1)
                        n = Int64.Parse(s, System.Globalization.NumberStyles.HexNumber);
                    else if (!string.IsNullOrEmpty(numberTextBox.Text))
                        n = Convert.ToInt64(numberTextBox.Text);
                }
                catch
                {
                }




                try
                {
                    if (!string.IsNullOrEmpty(numberTextBox.Text))
                    {
                        switch (numberType.SelectedIndex)
                        {
                            case (0):
                                dec = Convert.ToString(n);
                                hex = Convert.ToString(n, 16);
                                oct = Convert.ToString(n, 8);
                                bin = Convert.ToString(n, 2);
                                break;

                            case (1):
                                dec = Convert.ToString(n);
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(Convert.ToInt64(dec), 8);
                                bin = Convert.ToString(Convert.ToInt64(dec), 2);
                                break;

                            case (2):
                                dec = Convert.ToString(Convert.ToInt32(Convert.ToString(n), 8));
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(n);
                                bin = Convert.ToString(Convert.ToInt64(dec), 2);
                                break;

                            case (3):
                                dec = Convert.ToString(Convert.ToInt32(Convert.ToString(n), 2));
                                hex = Convert.ToString(Convert.ToInt64(dec), 16);
                                oct = Convert.ToString(Convert.ToInt64(dec), 8);
                                bin = Convert.ToString(n);
                                break;
                        }
                    }
                    else
                    {
                        dec = "";
                        hex = "";
                        oct = "";
                        bin = "";
                    }
                    DecimalResult.Text = dec;
                    HexadecimalResult.Text = hex.ToUpper();
                    OctalResult.Text = oct;
                    BinaryResult.Text = bin;
                }
                catch
                {
                    DialogResult result = (DialogResult)System.Windows.MessageBox.Show($"Invalid Value !\nValue must not be higher than {Int64.MaxValue} Decimal\nAllowed Characters for each value :\nDecimal: 1 2 3 4 5 6 7 8 9 0\nHexadecimal : 1 2 3 4 5 6 7 8 9 0 A B C D E F\n /!\\ (Length must not exceed 6)\nOctal : 1 2 3 4 5 6 7 0\nBinary : 1 0\n\nClear TextBox ?", "Error",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == DialogResult.Yes)
                    {
                        numberTextBox.Text = "";
                        DecimalResult.Text = "";
                        HexadecimalResult.Text = "";
                        OctalResult.Text = "";
                        BinaryResult.Text = "";
                    }

                }
            }
            else
                numberTextBox.Text = "";
        }


    }
}
