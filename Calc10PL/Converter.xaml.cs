using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Converter.xaml
    /// </summary>
    public partial class Converter : UserControl
    {
        public Converter()
        {
            InitializeComponent();
        }

        //Declaring all the arrays
        private readonly string[] AngleList = { "Kątów", "Radianów", "Gradów" };
        private readonly string[] DataList = { "Bitów", "Bajtów", "Kilobitów", "Kilobajtów", "Megabitów", "Megabajtów", "Gigabitów", "Gigabajtów", "Terabitów", "Terabajtów", "Petabitów", "Petabajtów", "Exabitów", "Exabajtów", "Zettabitów", "Zettabajtów", "Yottabitów", "Yottabajtów", };
        private readonly string[] EnergyList = { "Dżuli", "Kilodżuli", "Kilokalorii (Kcal)" };
        private readonly string[] TimeList = { "Mikrosekunda", "Milisekunda", "Sekunda", "Minuta", "Godzina", "Dzień", "Tydzień", "Miesiąc", "Rok" };
        private readonly string[] LengthList = { "Nanometrów", "Mikrometrów", "Milimetrów", "Centymetrów", "Metrów", "Kilometrów", "Cali", "Stóp", "Jardów" };
        private readonly string[] PowerList = { "Watów", "Kilowatów" };
        private readonly string[] PressureList = { "Atmosfer", "Barów", "Pascali" };
        private readonly string[] SpeedList = { "Centymetrów na Sekundę", "Metrów na Sekundę", "Kilometrów na Godzinę", "Mil na Godzinę", "Machów" };
        private readonly string[] SurfaceList = { "Milimetrów kwadratowych", "Centymetrów Kwadratowych", "Metrów Kwadratowych", "Hektarów", "Kilometrów Kwadratowych", "Cali Kwadratowych", "Stóp Kwadratowych", "Jardów Kwadratowych", "Mil Kwadratowych", };
        private readonly string[] TemperatureList = { "Stopni Celsjusza", "Fahrenheitów", "Kelvinów" };
        private readonly string[] VolumeList = { "Mililitrów", "Centymetrów Sześciennych", "Litrów", "Metrów Sześciennych", "Galonów", "Cali Sześciennych", "Stóp Sześciennych" };
        private readonly string[] WeightList = { "Miligramów", "Centygramów", "Decygramów", "Gramów", "Dekagramów", "Hektogramów", "Kilogramów", "Ton", "Uncji", "Funtów", "Ton (US)" };

        //Invert Button
        private void InvertButton_Click(object sender, RoutedEventArgs e)
        {
            int _temp = toUnitComboBox.SelectedIndex;
            string _temp2 = toUnitTextBox.Text;

            toUnitComboBox.SelectedIndex = fromUnitComboBox.SelectedIndex;
            fromUnitComboBox.SelectedIndex = _temp;

            toUnitTextBox.Text = fromUnitTextBox.Text;
            fromUnitTextBox.Text = _temp2;

        }

        //Auto Conversion
        private void fromUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Conversion();
            if (fromUnitTextBox.Text == "")
            {
                toUnitTextBox.Text = "";
            }
        }

        //Auto List Units Depending on the unit type
        private void unitListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (unitListComboBox.SelectedIndex == 0)
            {
                fromUnitComboBox.ItemsSource = AngleList;
            }

            if (unitListComboBox.SelectedIndex == 1)
            {
                fromUnitComboBox.ItemsSource = DataList;
            }

            if (unitListComboBox.SelectedIndex == 2)
            {
                fromUnitComboBox.ItemsSource = EnergyList;
            }

            if (unitListComboBox.SelectedIndex == 3)
            {
                fromUnitComboBox.ItemsSource = TimeList;
            }

            if (unitListComboBox.SelectedIndex == 4)
            {
                fromUnitComboBox.ItemsSource = LengthList;
            }

            if (unitListComboBox.SelectedIndex == 5)
            {
                fromUnitComboBox.ItemsSource = PowerList;
            }

            if (unitListComboBox.SelectedIndex == 6)
            {
                fromUnitComboBox.ItemsSource = PressureList;
            }

            if (unitListComboBox.SelectedIndex == 7)
            {
                fromUnitComboBox.ItemsSource = SpeedList;
            }

            if (unitListComboBox.SelectedIndex == 8)
            {
                fromUnitComboBox.ItemsSource = SurfaceList;
            }

            if (unitListComboBox.SelectedIndex == 9)
            {
                fromUnitComboBox.ItemsSource = TemperatureList;
            }

            if (unitListComboBox.SelectedIndex == 10)
            {
                fromUnitComboBox.ItemsSource = VolumeList;
            }

            if (unitListComboBox.SelectedIndex == 11)
            {
                fromUnitComboBox.ItemsSource = WeightList;
            }

            toUnitComboBox.ItemsSource = fromUnitComboBox.ItemsSource;
        }

        //Conversion TextBox
        private void fromUnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Conversion();
            if (fromUnitTextBox.Text == "")
            {
                toUnitTextBox.Text = "";
            }
        }



        //Conversion Method
        public void Conversion()
        {
            bool numOnly;
            try { long l2 = long.Parse(fromUnitTextBox.Text, System.Globalization.NumberStyles.HexNumber); numOnly = true; }
            catch { numOnly = false; }

            if (numOnly == true)
            {
                try
                {
                    if (!string.IsNullOrEmpty(fromUnitTextBox.Text) && !string.IsNullOrWhiteSpace(fromUnitTextBox.Text)
                        && !string.IsNullOrEmpty(Convert.ToString(fromUnitComboBox.SelectedItem)) && !string.IsNullOrEmpty(Convert.ToString(toUnitComboBox.SelectedItem)))
                    {
                        if (unitListComboBox.SelectedIndex == 0)
                        {
                            toUnitTextBox.Text = Convert.ToString(AngleConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 1)
                        {
                            toUnitTextBox.Text = Convert.ToString(DataConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 2)
                        {
                            toUnitTextBox.Text = Convert.ToString(EnergyConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 3)
                        {
                            toUnitTextBox.Text = Convert.ToString(TimeConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 4)
                        {
                            toUnitTextBox.Text = Convert.ToString(LengthConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 5)
                        {
                            toUnitTextBox.Text = Convert.ToString(PowerConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 6)
                        {
                            toUnitTextBox.Text = Convert.ToString(PressureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 7)
                        {
                            toUnitTextBox.Text = Convert.ToString(SpeedConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 8)
                        {
                            toUnitTextBox.Text = Convert.ToString(SurfaceConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 9)
                        {
                            toUnitTextBox.Text = Convert.ToString(TemperatureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 10)
                        {
                            toUnitTextBox.Text = Convert.ToString(VolumeConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else if (unitListComboBox.SelectedIndex == 11)
                        {
                            toUnitTextBox.Text = Convert.ToString(WeightConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));
                        }
                        else
                        {
                            toUnitTextBox.Text = "";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid Value !", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }


        }

        //Angle Conversion
        public double AngleConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                switch (index2)
                {
                    case (1):
                        return num * Math.PI / 180;
                    case (2):
                        return num * 200 / 180;
                }
            }
            else if (index1 == 1)
            {
                switch (index2)
                {
                    case (0):
                        return num * 180 / Math.PI;
                    case (2):
                        return num * 200 / Math.PI;
                }
            }
            else if (index1 == 2)
            {
                switch (index2)
                {
                    case (0):
                        return num * 180 / 200;
                    case (1):
                        return num * Math.PI / 200;
                }
            }

            return num;
        }

        //Data Conversion
        public double DataConversion(int index1, int index2, double num)
        {
            if (index1 == 2 || index1 == 3)
            {
                num = num / 0.001;
            }
            else if (index1 == 4 || index1 == 5)
            {
                num = num / 0.000001;
            }
            else if (index1 == 6 || index1 == 7)
            {
                num = num / 0.000000001;
            }
            else if (index1 == 8 || index1 == 9)
            {
                num = num / 0.000000000001;
            }
            else if (index1 == 10 || index1 == 11)
            {
                num = num / 0.000000000000001;
            }
            else if (index1 == 12 || index1 == 13)
            {
                num = num / 0.000000000000000001;
            }
            else if (index1 == 14 || index1 == 15)
            {
                num = num / 0.000000000000000000001;
            }
            else if (index1 == 16 || index1 == 17)
            {
                num = num / 0.000000000000000000000001;
            }
            else if (index2 == 2 || index2 == 3)
            {
                num = num * 0.001;
            }
            else if (index2 == 4 || index2 == 5)
            {
                num = num * 0.000001;
            }
            else if (index2 == 6 || index2 == 7)
            {
                num = num * 0.000000001;
            }
            else if (index2 == 8 || index2 == 9)
            {
                num = num * 0.000000000001;
            }
            else if (index2 == 10 || index2 == 11)
            {
                num = num * 0.000000000000001;
            }
            else if (index2 == 12 || index2 == 13)
            {
                num = num * 0.000000000000000001;
            }
            else if (index2 == 14 || index2 == 15)
            {
                num = num * 0.000000000000000000001;
            }
            else if (index2 == 16 || index2 == 17)
            {
                num = num * 0.000000000000000000000001;
            }

            if (index1 % 2 == 0 && index2 % 2 != 0)
            {
                return num / 8;
            }
            else if (index1 % 2 != 0 && index2 % 2 == 0)
            {
                return num * 8;
            }

            return num;
        }

        //Time Conversion
        public double TimeConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num / 60000000;
            }
            else if (index1 == 1)
            {
                num = num / 60000;
            }
            else if (index1 == 2)
            {
                num = num / 60;
            }
            else if (index1 == 4)
            {
                num = num * 60;
            }
            else if (index1 == 5)
            {
                num = num * 1440;
            }
            else if (index1 == 6)
            {
                num = num * 10080;
            }
            else if (index1 == 7)
            {
                num = num * 43800;
            }
            else if (index1 == 8)
            {
                num = num * 525600;
            }

            if (index2 == 0)
            {
                num = num * 60000000;
            }
            else if (index2 == 1)
            {
                num = num * 60000;
            }
            else if (index2 == 2)
            {
                num = num * 60;
            }
            else if (index2 == 4)
            {
                num = num / 60;
            }
            else if (index2 == 5)
            {
                num = num / 1440;
            }
            else if (index2 == 6)
            {
                num = num / 10080;
            }
            else if (index2 == 7)
            {
                num = num / 43800;
            }
            else if (index2 == 8)
            {
                num = num / 525600;
            }

            return num;
        }

        //Length Conversion
        public double LengthConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num / 1000000000;
            }
            else if (index1 == 1)
            {
                num = num / 1000000;
            }
            else if (index1 == 2)
            {
                num = num / 1000;
            }
            else if (index1 == 3)
            {
                num = num / 100;
            }
            else if (index1 == 5)
            {
                num = num * 1000;
            }
            else if (index1 == 6)
            {
                num = num / 39.37;
            }
            else if (index1 == 7)
            {
                num = num / 3.281;
            }
            else if (index1 == 8)
            {
                num = num / 1.094;
            }
            else if (index1 == 9)
            {
                num = num * 1609;
            }

            if (index2 == 0)
            {
                num = num * 1000000000;
            }
            else if (index2 == 1)
            {
                num = num * 1000000;
            }
            else if (index2 == 2)
            {
                num = num * 1000;
            }
            else if (index2 == 3)
            {
                num = num * 100;
            }
            else if (index2 == 5)
            {
                num = num / 1000;
            }
            else if (index2 == 6)
            {
                num = num * 39.37;
            }
            else if (index2 == 7)
            {
                num = num * 3.281;
            }
            else if (index2 == 8)
            {
                num = num * 1.094;
            }
            else if (index2 == 9)
            {
                num = num / 1609;
            }

            return num;
        }

        //Energy Conversion
        public double EnergyConversion(int index1, int index2, double num)
        {
            if (index1 == 0 && index2 == 1)
            {
                return num / 1000;
            }
            else if (index1 == 1 && index2 == 0)
            {
                return num * 1000;
            }

            if (index1 == 0 && index2 == 2)
            {
                return num / 4184;
            }
            else if (index1 == 1 && index2 == 2)
            {
                return num / 4.184;
            }
            else if (index1 == 2 && index2 == 0)
            {
                return num * 4184;
            }
            else if (index1 == 2 && index2 == 1)
            {
                return num * 4.184;
            }

            return num;
        }

        //Power Conversion
        public double PowerConversion(int index1, int index2, double num)
        {
            if (index1 == 0 && index2 == 1)
            {
                return num * 1000;
            }
            else if (index1 == 1 && index2 == 0)
            {
                return num / 1000;
            }

            return num;
        }

        //Pressure Conversion
        public double PressureConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                switch (index2)
                {
                    case (1):
                        return num * 1.013;
                    case (2):
                        return num * 101325;
                }
            }
            else if (index1 == 1)
            {
                switch (index2)
                {
                    case (0):
                        return num / 1.013;
                    case (2):
                        return num * 100000;
                }
            }
            else if (index1 == 2)
            {
                switch (index2)
                {
                    case (0):
                        return num / 101325;
                    case (1):
                        return num / 100000;
                }
            }

            return num;
        }

        //Speed Conversion
        public double SpeedConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num / 27.778;
            }
            else if (index1 == 1)
            {
                num = num * 3.6;
            }
            else if (index1 == 3)
            {
                num = num * 1.60934;
            }
            else if (index1 == 4)
            {
                num = num * 1234.8;
            }

            if (index2 == 0)
            {
                num = num * 27.778;
            }
            else if (index2 == 1)
            {
                num = num / 3.6;
            }
            else if (index2 == 3)
            {
                num = num / 1.60934;
            }
            else if (index2 == 4)
            {
                num = num / 1234.8;
            }

            return num;
        }

        //Surface Conversion
        public double SurfaceConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num / 1000000;
            }
            else if (index1 == 1)
            {
                num = num / 10000;
            }
            else if (index1 == 3)
            {
                num = num * 10000;
            }
            else if (index1 == 4)
            {
                num = num * 1000000;
            }
            else if (index1 == 5)
            {
                num = num / 1550;
            }
            else if (index1 == 6)
            {
                num = num / 10.764;
            }
            else if (index1 == 7)
            {
                num = num / 1.196;
            }
            else if (index1 == 8)
            {
                num = num * 2590000;
            }

            if (index2 == 0)
            {
                num = num * 1000000;
            }
            else if (index2 == 1)
            {
                num = num * 10000;
            }
            else if (index2 == 3)
            {
                num = num / 10000;
            }
            else if (index2 == 4)
            {
                num = num / 1000000;
            }
            else if (index2 == 5)
            {
                num = num * 1550;
            }
            else if (index2 == 6)
            {
                num = num * 10.764;
            }
            else if (index2 == 7)
            {
                num = num * 1.196;
            }
            else if (index2 == 8)
            {
                num = num / 2590000;
            }

            return num;
        }

        //Temperature Conversion
        public double TemperatureConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                switch (index2)
                {
                    case (1):
                        return (num * 9 / 5) + 32;
                    case (2):
                        return num + 273.15;
                }
            }
            else if (index1 == 1)
            {
                switch (index2)
                {
                    case (0):
                        return (num - 32) * 5 / 9;
                    case (2):
                        return (num - 32) * 5 / 9 + 273.15;
                }
            }
            else if (index1 == 2)
            {
                switch (index2)
                {
                    case (0):
                        return num - 273.15;
                    case (1):
                        return (num - 273.15) * 9 / 5 + 32;
                }
            }

            return num;
        }

        //Volume Conversion
        public double VolumeConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num / 1000;
            }
            else if (index1 == 1)
            {
                num = num / 1000;
            }
            else if (index1 == 3)
            {
                num = num * 1000;
            }
            else if (index1 == 4)
            {
                num = num * 4.546;
            }
            else if (index1 == 5)
            {
                num = num / 61.024;
            }
            else if (index1 == 6)
            {
                num = num / 28.317;
            }

            if (index2 == 0)
            {
                num = num * 1000;
            }
            else if (index2 == 1)
            {
                num = num * 1000;
            }
            else if (index2 == 3)
            {
                num = num / 1000;
            }
            else if (index2 == 4)
            {
                num = num / 4.546;
            }
            else if (index2 == 5)
            {
                num = num * 61.024;
            }
            else if (index2 == 6)
            {
                num = num * 28.317;
            }

            return num;
        }

        //Weight Conversion
        public double WeightConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
            {
                num = num * 1000;
            }
            else if (index1 == 1)
            {
                num = num * 100;
            }
            else if (index1 == 2)
            {
                num = num * 10;
            }
            else if (index1 == 4)
            {
                num = num / 10;
            }
            else if (index1 == 5)
            {
                num = num / 100;
            }
            else if (index1 == 6)
            {
                num = num / 1000;
            }
            else if (index1 == 7)
            {
                num = num / 1000000;
            }
            else if (index1 == 8)
            {
                num = num * 28.35;
            }
            else if (index1 == 9)
            {
                num = num * 435.592;
            }
            else if (index1 == 10)
            {
                num = num * 907185;
            }

            if (index2 == 0)
            {
                num = num / 1000;
            }
            else if (index2 == 1)
            {
                num = num / 100;
            }
            else if (index2 == 2)
            {
                num = num / 10;
            }
            else if (index2 == 4)
            {
                num = num * 10;
            }
            else if (index2 == 5)
            {
                num = num * 100;
            }
            else if (index2 == 6)
            {
                num = num * 1000;
            }
            else if (index2 == 7)
            {
                num = num * 1000000;
            }
            else if (index2 == 8)
            {
                num = num / 28.35;
            }
            else if (index2 == 9)
            {
                num = num / 435.592;
            }
            else if (index2 == 10)
            {
                num = num / 907185;
            }

            return num;
        }
    }
}
