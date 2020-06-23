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
using WPFModernUITest;
using ModernWpf.Controls;
using ModernWpf.Navigation;
using System.Net;
using System.IO;
using ModernWpf;
using System.Threading;
using System.Timers;
using Calc10;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //Method to check for Internet Connection
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            { return false; }
        }

        //Method for reading files 
        static string ReadSpecificLine(string filePath, int lineNumber)
        {
            string content = null;
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    for (int i = 1; i < lineNumber; i++)
                    {
                        file.ReadLine();

                        if (file.EndOfStream)
                        {
                            Console.WriteLine($"End of file.  The file only contains {i} lines.");
                            break;
                        }
                    }
                    content = file.ReadLine();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error reading the file: ");
                Console.WriteLine(e.Message);
            }

            return content;

        }

        //Auto Personalization And More On StartUp
        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var SettingsPath = System.IO.Path.Combine(appDataPath + "\\Calc10\\Settings.ini");

            if (ReadSpecificLine(SettingsPath, 2) == "null")
            {
                ThemeManager.Current.ApplicationTheme = null;
                ThemeSettingsUI.DefaultTheme.IsChecked = true;
            }
            else if (ReadSpecificLine(SettingsPath, 2) == "Dark")
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                ThemeSettingsUI.DefaultTheme.IsChecked = false;
                ThemeSettingsUI.DarkTheme.IsChecked = true;

            }
            else if (ReadSpecificLine(SettingsPath, 2) == "Light")
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                ThemeSettingsUI.DefaultTheme.IsChecked = false;
                ThemeSettingsUI.LightTheme.IsChecked = true;
            }

            if (!string.IsNullOrEmpty(ReadSpecificLine(SettingsPath, 4)))
            {
                Color color = (Color)ColorConverter.ConvertFromString(ReadSpecificLine(SettingsPath, 4));
                ThemeManager.Current.AccentColor = color;
            }

            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
            {
                ConverterUI.TextBlock1.Foreground = Brushes.White;
                ConverterUI.TextBlock2.Foreground = Brushes.White;
                ConverterUI.TextBlock3.Foreground = Brushes.White;
                CalcUI.PendingOperation.Foreground = Brushes.White;
                CurrencyUI.TextBox1.Foreground = Brushes.White;
                CurrencyUI.TextBox2.Foreground = Brushes.White;
                CurrencyUI.TextBox3.Foreground = Brushes.White;
                CurrencyUI.TextBox4.Foreground = Brushes.White;
                CustomHeader.Foreground = Brushes.White;
                DateUI.TextBlock1.Foreground = Brushes.White;
                DateUI.TextBlock2.Foreground = Brushes.White;
                DateUI.TextBlock3.Foreground = Brushes.White;
                DateUI.TextBlock4.Foreground = Brushes.White;
                DateUI.TextBlock5.Foreground = Brushes.White;
                DateUI.TextBlock6.Foreground = Brushes.White;
                DateUI.TextBlock7.Foreground = Brushes.White;
                DateUI.TextBlock8.Foreground = Brushes.White;
                ProgrammerUI.textBlock1.Foreground = Brushes.White;
                ProgrammerUI.textBlock2.Foreground = Brushes.White;
                ProgrammerUI.textBlock3.Foreground = Brushes.White;
                ProgrammerUI.textBlock4.Foreground = Brushes.White;
                ProgrammerUI.textBlock5.Foreground = Brushes.White;
                ProgrammerUI.textBlock6.Foreground = Brushes.White;
            }
            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Light)
            {
                ConverterUI.TextBlock1.Foreground = Brushes.Black;
                ConverterUI.TextBlock2.Foreground = Brushes.Black;
                ConverterUI.TextBlock3.Foreground = Brushes.Black;
                CalcUI.PendingOperation.Foreground = Brushes.Black;
                CurrencyUI.TextBox1.Foreground = Brushes.Black;
                CurrencyUI.TextBox2.Foreground = Brushes.Black;
                CurrencyUI.TextBox3.Foreground = Brushes.Black;
                CurrencyUI.TextBox4.Foreground = Brushes.Black;
                CustomHeader.Foreground = Brushes.Black;
                DateUI.TextBlock1.Foreground = Brushes.Black;
                DateUI.TextBlock2.Foreground = Brushes.Black;
                DateUI.TextBlock3.Foreground = Brushes.Black;
                DateUI.TextBlock4.Foreground = Brushes.Black;
                DateUI.TextBlock5.Foreground = Brushes.Black;
                DateUI.TextBlock6.Foreground = Brushes.Black;
                DateUI.TextBlock7.Foreground = Brushes.Black;
                DateUI.TextBlock8.Foreground = Brushes.Black;
                ProgrammerUI.textBlock1.Foreground = Brushes.Black;
                ProgrammerUI.textBlock2.Foreground = Brushes.Black;
                ProgrammerUI.textBlock3.Foreground = Brushes.Black;
                ProgrammerUI.textBlock4.Foreground = Brushes.Black;
                ProgrammerUI.textBlock5.Foreground = Brushes.Black;
                ProgrammerUI.textBlock6.Foreground = Brushes.Black;
            }
            CustomHeader.Text = " Calculatrice";
            NavView.SelectedItem = CalcNavView;
        }

        //Navigation View Management
        int SelectedIndex = 0;
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (NavView.SelectedItem == CalcNavView)
                SelectedIndex = 1;
            else if (NavView.SelectedItem == CurrencyNavView)
                SelectedIndex = 2;
            else if (NavView.SelectedItem == ConverterNavView)
                SelectedIndex = 3;
            else if (NavView.SelectedItem == ScientificNavView)
                SelectedIndex = 4;
            else if (NavView.SelectedItem == ProgNavView)
                SelectedIndex = 5;
            else if (NavView.SelectedItem == DateNavView)
                SelectedIndex = 6;
            else
                SelectedIndex = 7;

            if (SelectedIndex == 1)
                CustomHeader.Text = " Calculatrice";
            if (SelectedIndex == 2)
                CustomHeader.Text = " Convertisseur";
            if (SelectedIndex == 3)
                CustomHeader.Text = " Devise";
            if (SelectedIndex == 4)
                CustomHeader.Text = " Scientifique";
            if (SelectedIndex == 5)
                CustomHeader.Text = " Programmeur";
            if (SelectedIndex == 6)
                CustomHeader.Text = " Calcul de Date";
            if (SelectedIndex == 7)
                CustomHeader.Text = " Paramètres";

            CalcUI.Visibility = Visibility.Hidden;
            CurrencyUI.Visibility = Visibility.Hidden;
            ThemeSettingsUI.Visibility = Visibility.Hidden;
            ConverterUI.Visibility = Visibility.Hidden;
            ScientificUI.Visibility = Visibility.Hidden;
            ProgrammerUI.Visibility = Visibility.Hidden;
            DateUI.Visibility = Visibility.Hidden;

            MainWindows.Width = 370;
            MainWindows.Height = 450;

            if (SelectedIndex == 1 || SelectedIndex == 4)
            {
                CalcUI.Visibility = Visibility.Visible;
                MainWindows.Height = 450;
            }
            if (SelectedIndex == 2)
            {
                ConverterUI.Visibility = Visibility.Visible;
                MainWindows.Height = 520;
            }
            if (SelectedIndex == 3)
            {
                CurrencyUI.Visibility = Visibility.Visible;
                MainWindows.Height = 600;
                if (!CheckForInternetConnection())
                    MessageBox.Show("The Currency Converter won't work without Internet Connection.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (SelectedIndex == 4)
            {
                ScientificUI.Visibility = Visibility.Visible;
                MainWindows.Width = 620;
            }
            if (SelectedIndex == 5)
            {
                ProgrammerUI.Visibility = Visibility.Visible;
                MainWindows.Height = 500;
            }
           
            if (SelectedIndex == 6)
            {
                DateUI.Visibility = Visibility.Visible;
            }
            if (SelectedIndex == 7)
            {
                ThemeSettingsUI.Visibility = Visibility.Visible;
                MainWindows.Height = 350;

            }

        }

        //Set color of text depending on the theme
        private async void ThemeSettingsUI_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(50);

            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
            {
                ConverterUI.TextBlock1.Foreground = Brushes.White;
                ConverterUI.TextBlock2.Foreground = Brushes.White;
                ConverterUI.TextBlock3.Foreground = Brushes.White;
                CalcUI.PendingOperation.Foreground = Brushes.White;
                CurrencyUI.TextBox1.Foreground = Brushes.White;
                CurrencyUI.TextBox2.Foreground = Brushes.White;
                CurrencyUI.TextBox3.Foreground = Brushes.White;
                CurrencyUI.TextBox4.Foreground = Brushes.White;
                CustomHeader.Foreground = Brushes.White;
                DateUI.TextBlock1.Foreground = Brushes.White;
                DateUI.TextBlock2.Foreground = Brushes.White;
                DateUI.TextBlock3.Foreground = Brushes.White;
                DateUI.TextBlock4.Foreground = Brushes.White;
                DateUI.TextBlock5.Foreground = Brushes.White;
                DateUI.TextBlock6.Foreground = Brushes.White;
                DateUI.TextBlock7.Foreground = Brushes.White;
                DateUI.TextBlock8.Foreground = Brushes.White;
                ProgrammerUI.textBlock1.Foreground = Brushes.White;
                ProgrammerUI.textBlock2.Foreground = Brushes.White;
                ProgrammerUI.textBlock3.Foreground = Brushes.White;
                ProgrammerUI.textBlock4.Foreground = Brushes.White;
                ProgrammerUI.textBlock5.Foreground = Brushes.White;
                ProgrammerUI.textBlock6.Foreground = Brushes.White;
            }
            if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Light)
            {
                ConverterUI.TextBlock1.Foreground = Brushes.Black;
                ConverterUI.TextBlock2.Foreground = Brushes.Black;
                ConverterUI.TextBlock3.Foreground = Brushes.Black;
                CalcUI.PendingOperation.Foreground = Brushes.Black;
                CurrencyUI.TextBox1.Foreground = Brushes.Black;
                CurrencyUI.TextBox2.Foreground = Brushes.Black;
                CurrencyUI.TextBox3.Foreground = Brushes.Black;
                CurrencyUI.TextBox4.Foreground = Brushes.Black;
                CustomHeader.Foreground = Brushes.Black;
                DateUI.TextBlock1.Foreground = Brushes.Black;
                DateUI.TextBlock2.Foreground = Brushes.Black;
                DateUI.TextBlock3.Foreground = Brushes.Black;
                DateUI.TextBlock4.Foreground = Brushes.Black;
                DateUI.TextBlock5.Foreground = Brushes.Black;
                DateUI.TextBlock6.Foreground = Brushes.Black;
                DateUI.TextBlock7.Foreground = Brushes.Black;
                DateUI.TextBlock8.Foreground = Brushes.Black;
                ProgrammerUI.textBlock1.Foreground = Brushes.Black;
                ProgrammerUI.textBlock2.Foreground = Brushes.Black;
                ProgrammerUI.textBlock3.Foreground = Brushes.Black;
                ProgrammerUI.textBlock4.Foreground = Brushes.Black;
                ProgrammerUI.textBlock5.Foreground = Brushes.Black;
                ProgrammerUI.textBlock6.Foreground = Brushes.Black;
                
            }
        }

        //ABOUT Window
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            var newW = new About();
            newW.Show(); // works
        }
    }
}
