using System;
using System.Windows;
using System.Windows.Controls;
using WPFModernUITest;

namespace Calc10
{
    /// <summary>
    /// Logique d'interaction pour Scientific.xaml
    /// </summary>
    public partial class Scientific : UserControl
    {
        private Calc calc;
        public Scientific()
        {
            InitializeComponent();
        }

        public double factorial(double num)
        {
            double result = 1;
            while (num != 1)
            {
                result *= num;
                num--;
            }
            return result;
        }

        private void ScientificUC_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            calc = parentWindow.FindName("CalcUI") as Calc;
        }

        public double ScientificFunctions(string index, string num)
        {

            if (!string.IsNullOrEmpty(calc.MainTextBox.Text))
            {
                switch (index)
                {
                    case ("pow"):
                        return Math.Pow(Convert.ToDouble(num), 2);

                    case ("cube"):
                        return Math.Pow(Convert.ToDouble(num), 3);

                    case ("powTo"):
                        calc.MainTextBox.Text = "0";
                        calc.PendingOperation.Text = num + " ^";
                        calc.storeValue.Text = Convert.ToString(num);
                        break;

                    case ("10powTo"):
                        return Math.Pow(10, Convert.ToDouble(num));

                    case ("powTo-1"):
                        return Math.Pow(Convert.ToDouble(num), -1);

                    case ("sqrt"):
                        return Math.Sqrt(Convert.ToDouble(num));


                    case ("sin"):
                        return Math.Sin(Convert.ToDouble(num) * Math.PI / 180);

                    case ("cos"):
                        return Math.Cos(Convert.ToDouble(num) * Math.PI / 180);

                    case ("tan"):
                        return Math.Tan(Convert.ToDouble(num) * Math.PI / 180);

                    case ("Asin"):
                        return Math.Asin(Convert.ToDouble(num) * Math.PI / 180);

                    case ("Acos"):
                        return Math.Acos(Convert.ToDouble(num) * Math.PI / 180);

                    case ("Atan"):
                        return Math.Atan(Convert.ToDouble(num) * Math.PI / 180);


                    case ("pi"):
                        return Math.PI;

                    case ("e"):
                        return Math.E;

                    case ("log"):
                        return Math.Log(Convert.ToDouble(num));

                    case ("rand"):
                        System.Random random = new System.Random();
                        return random.NextDouble();

                    case ("%"):
                        if (!string.IsNullOrEmpty(calc.MainTextBox.Text) && !string.IsNullOrEmpty(calc.PendingOperation.Text))
                        {
                            int temp = calc.PendingOperation.Text.IndexOf(" ");
                            string temp2 = calc.PendingOperation.Text.Substring(0, temp);
                            return Convert.ToDouble(calc.MainTextBox.Text) / 100 * Convert.ToDouble(temp2);
                        }
                        break;

                    case ("fact"):
                        double n = Convert.ToDouble(num);
                        double result = 1;
                        while (n != 1)
                        {
                            result *= n;
                            n--;
                        }
                        return result;


                    case ("abs"):
                        return Math.Abs(Convert.ToDouble(num));

                    case ("floor"):
                        return Math.Floor(Convert.ToDouble(num));

                    case ("ceiling"):
                        return Math.Ceiling(Convert.ToDouble(num));

                }
            }

            num = Convert.ToString("0");
            return Convert.ToDouble(num);
        }

        //First Column
        private void powerButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("pow", calc.MainTextBox.Text));
        }

        private void cubeButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("cube", calc.MainTextBox.Text));
        }

        private void powerToXButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("powTo", calc.MainTextBox.Text));
            calc.MainTextBox.Text = "";
        }

        private void powerOfTenToXButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("10powTo", calc.MainTextBox.Text));
        }

        private void powerofXtoXMinus1Button_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("powTo-1", calc.MainTextBox.Text));
        }

        private void squareRootButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("sqrt", calc.MainTextBox.Text));
        }

        //Second Column
        private void sinButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("sin", calc.MainTextBox.Text));
        }

        private void cosButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("cos", calc.MainTextBox.Text));
        }

        private void tanButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("tan", calc.MainTextBox.Text));
        }

        private void AsinButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("Asin", calc.MainTextBox.Text));
        }

        private void AcosButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("Acos", calc.MainTextBox.Text));
        }

        private void AtanButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("Atan", calc.MainTextBox.Text));
        }

        //Third Column
        private void piButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("pi", calc.MainTextBox.Text));
        }

        private void eButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("e", calc.MainTextBox.Text));
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("log", calc.MainTextBox.Text));
        }

        private void ranButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("rand", calc.MainTextBox.Text));
        }

        private void precentButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("%", calc.MainTextBox.Text));
        }

        private void factButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("fact", calc.MainTextBox.Text));
        }

        //Fourth Column
        private void absButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("abs", calc.MainTextBox.Text));
        }

        private void floorButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("floor", calc.MainTextBox.Text));
        }

        private void ceilingButton_Click(object sender, RoutedEventArgs e)
        {
            calc.MainTextBox.Text = Convert.ToString(ScientificFunctions("ceiling", calc.MainTextBox.Text));
        }
    }
}
