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

namespace Calc10
{
    /// <summary>
    /// Logique d'interaction pour MinimalMode.xaml
    /// </summary>
    public partial class MinimalMode : UserControl
    {
        public MinimalMode()
        {
            InitializeComponent();
        }

        private void minimalModeQuitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            MiniMalModeUIUC.Visibility = Visibility.Hidden;
            mainWindow.NavView.Visibility = Visibility.Visible;
        }
    }
}
