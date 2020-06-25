using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ModernWpf;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Dark Theme Button
        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            SaveSettings();
        }

        //Light Theme Button
        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
            SaveSettings();
        }

        //Default Button Click
        private void DefaultTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = null;
            SaveSettings();
        }

        //Save settings on close of flyout
        private void AccentColorFlyout_Closed(object sender, object e)
        {
            SaveSettings();
        }

        //Save Settings Method
        public void SaveSettings()
        {
            if (SettingsUIUC.Visibility == Visibility.Visible)
            {
                string AccentColor, CurrentTheme;

                //Color color2 = (Color)ColorConverter.ConvertFromString("#FF0063B1");

                if (DefaultTheme.IsChecked == true)
                {
                    CurrentTheme = "null";
                }
                else
                {
                    CurrentTheme = Convert.ToString(ThemeManager.Current.ActualApplicationTheme);
                }
                AccentColor = Convert.ToString(ThemeManager.Current.AccentColor);

                string[] lines = { "[Theme]", CurrentTheme, "[Accent Color]", AccentColor };

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                try { Directory.CreateDirectory(appDataPath + "\\Calc10"); }
                catch { }


                try { System.IO.File.WriteAllLines(appDataPath + "\\Calc10\\Settings.ini", lines); }
                catch { }
            }
        }

        //Custom Hex Code
        private void customHexApplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Color color = (Color)ColorConverter.ConvertFromString(customHexCodeTextBox.Text);
                ThemeManager.Current.AccentColor = color;
            }
            catch { MessageBox.Show("Invalid Hex Code", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }


        private void DropDownButton_Click(object sender, RoutedEventArgs e)
        {
            customHexCodeTextBox.Text = Convert.ToString(ThemeManager.Current.ActualAccentColor);
        }

        private void customHexCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (customHexCodeTextBox.Text.Length >= 2)
            {
                customHexCodeTextBox.Text = "#" + customHexCodeTextBox.Text.Substring(1);
            }
            else
            {
                customHexCodeTextBox.Text = "#";
            }
        }

    }
}
