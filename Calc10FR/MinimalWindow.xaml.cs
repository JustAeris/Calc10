using System.Windows;

namespace Calc10
{
    /// <summary>
    /// Logique d'interaction pour MinimalWindow.xaml
    /// </summary>
    public partial class MinimalWindow : Window
    {
        public MinimalWindow()
        {
            InitializeComponent();
        }

        private void minimalModeQuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
