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
using System.Windows.Shapes;

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
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
