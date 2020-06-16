﻿using System;
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

        //Auto personalization
        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            if (ReadSpecificLine("Settings.ini", 2) == "null")
            {
                ThemeManager.Current.ApplicationTheme = null;
                ThemeSettingsUI.DefaultTheme.IsChecked = true;
            }
            else if (ReadSpecificLine("Settings.ini", 2) == "Dark")
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                ThemeSettingsUI.DefaultTheme.IsChecked = false;
                ThemeSettingsUI.DarkTheme.IsChecked = true;

            }
            else if (ReadSpecificLine("Settings.ini", 2) == "Light")
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                ThemeSettingsUI.DefaultTheme.IsChecked = false;
                ThemeSettingsUI.LightTheme.IsChecked = true;
            }


            if (!string.IsNullOrEmpty(ReadSpecificLine("Settings.ini", 4)))
            {
                Color color = (Color)ColorConverter.ConvertFromString(ReadSpecificLine("Settings.ini", 4));
                ThemeManager.Current.AccentColor = color;
            }

            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Dark)
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
            }
            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light)
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
            }
            NavView.SelectedItem = "ModernWpf.Controls.NavigationViewItem: Calculator";
        }





        int SelectedIndex = 0;
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Calculator")
                SelectedIndex = 1;
            else if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Converter")
                SelectedIndex = 2;
            else if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Currency")
                SelectedIndex = 3;
            else if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Scientific")
                SelectedIndex = 4;
            else if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Programmer")
                SelectedIndex = 5;
            else if (Convert.ToString(NavView.SelectedItem) == "ModernWpf.Controls.NavigationViewItem: Date Calcul")
                SelectedIndex = 6;
            else
                SelectedIndex = 7;

            if (SelectedIndex == 1)
                CustomHeader.Text = " Calculator";
            if (SelectedIndex == 2)
                CustomHeader.Text = " Converter";
            if (SelectedIndex == 3)
                CustomHeader.Text = " Currency";
            if (SelectedIndex == 4)
                CustomHeader.Text = " Scientific";
            if (SelectedIndex == 5)
                CustomHeader.Text = " Programmer WIP";
            if (SelectedIndex == 6)
                CustomHeader.Text = " Date Calcul WIP";
            if (SelectedIndex == 7)
                CustomHeader.Text = " Settings";

            CalcUI.Visibility = Visibility.Hidden;
            CurrencyUI.Visibility = Visibility.Hidden;
            ThemeSettingsUI.Visibility = Visibility.Hidden;
            ConverterUI.Visibility = Visibility.Hidden;

            if (SelectedIndex == 1)
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
            //if (SelectedIndex != 4)
            //    NavView.Header = "Scientific";
            //if (SelectedIndex != 5)
            //    NavView.Header = "WIP";
            //if (SelectedIndex != 6)
            //    NavView.Header = "Date Calcul";
            if (SelectedIndex == 7)
            {
                ThemeSettingsUI.Visibility = Visibility.Visible;
                MainWindows.Height = 350;

            }

            MainWindow mainWindow = new MainWindow();

        }


        

        public static MainWindow C1;

        void Awake()
        {
            C1 = this;
        }
        public void ChangeTextColor()
        {
            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Dark)
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
            }
            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light)
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
            }
        }

    }
}