using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calc10;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Calc.xaml
    /// </summary>
    public partial class Calc : UserControl
    {
        public Calc()
        {
            InitializeComponent();
        }

        //GLOBAL VARIABLES AND OTHER
        private readonly string fatalerrmessage = "Oops, a fatal error has occured !", fatalerrtitle = "Fatal Error !";

        private bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonEqual.Focus();
        }

        //NUMPAD
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "1";
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "2";
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "3";
            }
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "4";
            }
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "5";
            }
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "6";
            }
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "7";
            }
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "8";
            }
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "9";
            }
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                if (!MainTextBox.Text.Contains(","))
                {
                    MainTextBox.Text = MainTextBox.Text + ",";
                }
            }
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= MainTextBox.MaxLength))
            {
                MainTextBox.Text = MainTextBox.Text + "0";
            }
        }
        private void Button00_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainTextBox.Text.Length >= (MainTextBox.MaxLength) - 1))
            {
                MainTextBox.Text = MainTextBox.Text + "00";
            }
        }

        //CLEAR BUTTONS
        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                MainTextBox.Text = MainTextBox.Text.Remove(MainTextBox.Text.Length - 1, 1);
            }
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            PendingOperation.Text = ""; MainTextBox.Text = ""; num1 = 0; num2 = 0;
        }

        //OPERATORS
        private double num1;
        private double num2;
        private double results;
        private string index;

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                try
                { num1 = Convert.ToDouble(MainTextBox.Text); }
                catch
                {
                    MessageBox.Show(fatalerrmessage, fatalerrtitle);
                    PendingOperation.Text = ""; MainTextBox.Text = ""; num1 = 0; num2 = 0;
                }
            }

            index = "add";
            MainTextBox.Text = "";
            PendingOperation.Text = num1 + " +";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                try
                { num1 = Convert.ToDouble(MainTextBox.Text); }
                catch
                {
                    MessageBox.Show(fatalerrmessage, fatalerrtitle);
                    PendingOperation.Text = ""; MainTextBox.Text = ""; num1 = 0; num2 = 0;
                }
            }

            index = "minus";
            MainTextBox.Text = "";
            PendingOperation.Text = num1 + " -";
        }

        private void ButtonTimes_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                try
                { num1 = Convert.ToDouble(MainTextBox.Text); }
                catch
                {
                    MessageBox.Show(fatalerrmessage, fatalerrtitle);
                    PendingOperation.Text = ""; MainTextBox.Text = ""; num1 = 0; num2 = 0;
                }
            }

            index = "times";
            MainTextBox.Text = "";
            PendingOperation.Text = num1 + " *";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                try
                { num1 = Convert.ToDouble(MainTextBox.Text); }
                catch
                {
                    MessageBox.Show(fatalerrmessage, fatalerrtitle);
                    PendingOperation.Text = ""; MainTextBox.Text = ""; num1 = 0; num2 = 0;
                }
            }

            index = "divide";
            MainTextBox.Text = "";
            PendingOperation.Text = num1 + " /";
        }

        private void ButtonEqual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(MainTextBox.Text))
                {
                    num2 = Convert.ToDouble(MainTextBox.Text);
                }

                if (index == "add")
                {
                    results = num1 + num2;
                }
                else if (index == "minus")
                {
                    results = num1 - num2;
                }
                else if (index == "times")
                {
                    results = num1 * num2;
                }
                else if (index == "divide")
                {
                    results = num1 / num2;
                }
                else if (PendingOperation.Text.Contains("^"))
                {
                    results = Math.Pow(Convert.ToDouble(storeValue.Text), num2);
                }

                MainTextBox.Text = Convert.ToString(results);

                storeValue.Text = "";
                PendingOperation.Text = "";
                num1 = 0;
                num2 = 0;
            }
        }



        //Equal Button
        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                num2 = Convert.ToDouble(MainTextBox.Text);
            }

            if (index == "add")
            {
                results = num1 + num2;
            }
            else if (index == "minus")
            {
                results = num1 - num2;
            }
            else if (index == "times")
            {
                results = num1 * num2;
            }
            else if (index == "divide")
            {
                results = num1 / num2;
            }
            else if (PendingOperation.Text.Contains("^"))
            {
                results = Math.Pow(Convert.ToDouble(storeValue.Text), num2);
            }

            MainTextBox.Text = Convert.ToString(results);

            storeValue.Text = "";
            PendingOperation.Text = "";
            num1 = 0;
            num2 = 0;
        }

        //MINIMAL MODE
        private void enterMinimalModeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Hide();
            MinimalWindow newW = new MinimalWindow();
            newW.Show(); // works
        }
    }
}
