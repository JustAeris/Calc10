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

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Converter.xaml
    /// </summary>
    public partial class Converter : UserControl
    {
        string[] AngleList = { "Degrees", "Radians", "Grades" };
        string[] DataList = { "Bits", "Octet", "KiloBit", "KiloOctet / KiloByte", "MegaBit", "MegaOctet / MegaByte", "GigaBit", "GigaOctet / GigaByte", 
            "TeraBit", "TeraOctet / TeraByte", "PetaBit", "PetaOctet / PetaByte", "ExaBit", "ExaOctet / ExaByte", "ZettaBit", "ZettaOctet / ZettaByte", "YottaBit", "YottaOctet / YottaByte", };
        string[] EnergyList = { "Joule", "KiloJoule", "Food Calorie (Kcal)" };
        string[] TimeList = { "MicroSecond", "MilliSecond", "Second", "Minute", "Hour", "Day", "Week", "Month", "Year" };
        string[] LengthList = { "NanoMeter", "MicroMeter", "MilliMeter", "CentiMeter" ,"Meter", "KiloMeter"};
        string[] PowerList = { "Watt", "KiloWatt" };
        string[] PressureList = { "Atmosphere", "Bar", "Pascal" };
        string[] SpeedList = { "CentiMeter per Second", "Meter per Second", "KiloMeter per Hour", "Mach"};
        string[] SurfaceList = { "Square MilliMeter", "Square CentiMeter", "Square Meter", "Hectare", "Square KiloMeter", };
        string[] TemperatureList = { "Celsuis", "Fahrenheit", "Kelvin" };
        string[] VolumeList = { "MilliMeter", "Cubic CentiMeter", "Liter", "Cubic Meter" };
        string[] WeightList = { "MilliGram", "CentiGram", "DeciGram", "Gram", "DecaGram", "HectoGram", "KiloGram", "Tonne", };

        public Converter()
        {
            InitializeComponent();
        }

        private void InvertButton_Click(object sender, RoutedEventArgs e)
        {
            int _temp = toUnitComboBox.SelectedIndex;
            string _temp2 = toUnitTextBox.Text;

            toUnitComboBox.SelectedIndex = fromUnitComboBox.SelectedIndex;
            fromUnitComboBox.SelectedIndex = _temp;

            toUnitTextBox.Text = fromUnitTextBox.Text;
            fromUnitTextBox.Text = _temp2;

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fromUnitTextBox.Text))
            {
                if (unitListComboBox.SelectedIndex == 0)
                    toUnitTextBox.Text = Convert.ToString(AngleConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 1)
                    toUnitTextBox.Text = Convert.ToString(DataConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 2)
                    toUnitTextBox.Text = Convert.ToString(EnergyConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));


                if (unitListComboBox.SelectedIndex == 5)
                    toUnitTextBox.Text = Convert.ToString(PowerConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 6)
                    toUnitTextBox.Text = Convert.ToString(PressureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 7)
                    toUnitTextBox.Text = Convert.ToString(SpeedConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 9)
                    toUnitTextBox.Text = Convert.ToString(TemperatureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));


            }
            else
                toUnitTextBox.Text = "";
            RefreshButton.IsEnabled = false;
        }

        private void fromUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshButton.IsEnabled = true;
        }

        private void unitListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (unitListComboBox.SelectedIndex == 0)
                fromUnitComboBox.ItemsSource = AngleList;

            if (unitListComboBox.SelectedIndex == 1)
                fromUnitComboBox.ItemsSource = DataList;

            if (unitListComboBox.SelectedIndex == 2)
                fromUnitComboBox.ItemsSource = EnergyList;

            if (unitListComboBox.SelectedIndex == 3)
                fromUnitComboBox.ItemsSource = TimeList;

            if (unitListComboBox.SelectedIndex == 4)
                fromUnitComboBox.ItemsSource = LengthList;

            if (unitListComboBox.SelectedIndex == 5)
                fromUnitComboBox.ItemsSource = PowerList;

            if (unitListComboBox.SelectedIndex == 6)
                fromUnitComboBox.ItemsSource = PressureList;

            if (unitListComboBox.SelectedIndex == 7)
                fromUnitComboBox.ItemsSource = SpeedList;

            if (unitListComboBox.SelectedIndex == 8)
                fromUnitComboBox.ItemsSource = SurfaceList;

            if (unitListComboBox.SelectedIndex == 9)
                fromUnitComboBox.ItemsSource = TemperatureList;

            if (unitListComboBox.SelectedIndex == 10)
                fromUnitComboBox.ItemsSource = VolumeList;

            if (unitListComboBox.SelectedIndex == 11)
                fromUnitComboBox.ItemsSource = WeightList;

            toUnitComboBox.ItemsSource = fromUnitComboBox.ItemsSource;

            RefreshButton.IsEnabled = true;

        }
        private void fromUnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fromUnitTextBox.Text))
            {
                if (unitListComboBox.SelectedIndex == 0)
                    toUnitTextBox.Text = Convert.ToString(AngleConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 1)
                    toUnitTextBox.Text = Convert.ToString(DataConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 2)
                    toUnitTextBox.Text = Convert.ToString(EnergyConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 3)
                    toUnitTextBox.Text = Convert.ToString(TimeConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 5)
                    toUnitTextBox.Text = Convert.ToString(PowerConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 6)
                    toUnitTextBox.Text = Convert.ToString(PressureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 7)
                    toUnitTextBox.Text = Convert.ToString(SpeedConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                if (unitListComboBox.SelectedIndex == 9)
                    toUnitTextBox.Text = Convert.ToString(TemperatureConversion(fromUnitComboBox.SelectedIndex, toUnitComboBox.SelectedIndex, Convert.ToDouble(fromUnitTextBox.Text)));

                
            }
            else
                toUnitTextBox.Text = "";
            RefreshButton.IsEnabled = true;
        }



        public double AngleConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
                switch (index2)
                {
                    case (1):
                        return num * Math.PI / 180;
                    case (2):
                        return num * 200 / 180;
                }
            else if (index1 == 1)
                switch (index2)
                {
                    case (0):
                        return num * 180 / Math.PI;
                    case (2):
                        return num * 200 / Math.PI;
                }
            else if (index1 == 2)
                switch (index2)
                {
                    case (0):
                        return num * 180 / 200;
                    case (1):
                        return num * Math.PI / 200;
                }


            return num;
        }

        public double DataConversion(int index1, int index2, double num)
        {
            if (index1 == 2 || index1 == 3)
                num = num / 0.001;
            if (index1 == 4 || index1 == 5)
                num = num / 0.000001;
            if (index1 == 6 || index1 == 7)
                num = num / 0.000000001;
            if (index1 == 8 || index1 == 9)
                num = num / 0.000000000001;
            if (index1 == 10 || index1 == 11)
                num = num / 0.000000000000001;
            if (index1 == 12 || index1 == 13)
                num = num / 0.000000000000000001;
            if (index1 == 14 || index1 == 15)
                num = num / 0.000000000000000000001;
            if (index1 == 16 || index1 == 17)
                num = num / 0.000000000000000000000001;

            if (index2 == 2 || index2 == 3)
                num = num * 0.001;
            if (index2 == 4 || index2 == 5)
                num = num * 0.000001;
            if (index2 == 6 || index2 == 7)
                num = num * 0.000000001;
            if (index2 == 8 || index2 == 9)
                num = num * 0.000000000001;
            if (index2 == 10 || index2 == 11)
                num = num * 0.000000000000001;
            if (index2 == 12 || index2 == 13)
                num = num * 0.000000000000000001;
            if (index2 == 14 || index2 == 15)
                num = num * 0.000000000000000000001;
            if (index2 == 16 || index2 == 17)
                num = num * 0.000000000000000000000001;

            if (index1 % 2 == 0 && index2 % 2 != 0)
                return num / 8;
            if (index1 % 2 != 0 && index2 % 2 == 0)
                return num * 8;

            return num;
        }

        public double TimeConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
                num = num / 60000000;
            if (index1 == 1)
                num = num / 60000;
            if (index1 == 2)
                num = num / 60;
            if (index1 == 4)
                num = num * 60;
            if (index1 == 5)
                num = num * 1440;
            if (index1 == 6)
                num = num * 10080;
            if (index1 == 7)
                num = num * 43800;
            if (index1 == 8)
                num = num * 525600;

            if (index2 == 0)
                num = num * 60000000;
            if (index2 == 1)
                num = num * 60000;
            if (index2 == 2)
                num = num * 60;
            if (index2 == 4)
                num = num / 60;
            if (index2 == 5)
                num = num / 1440;
            if (index2 == 6)
                num = num / 10080;
            if (index2 == 7)
                num = num / 43800;
            if (index2 == 8)
                num = num / 525600;

            return num;
        }

        public double LengthConversion(int index1, int index2, double num)
        {



            return num;
        }

        public double EnergyConversion(int index1, int index2, double num)
        {
            if (index1 == 0 && index2 == 1)
                return num / 1000;
            if (index1 == 1 && index2 == 0)
                return num * 1000;

            if (index1 == 0 && index2 == 2)
                return num / 4184;
            if (index1 == 1 && index2 == 2)
                return num / 4.184;
            if (index1 == 2 && index2 == 0)
                return num * 4184;
            if (index1 == 2 && index2 == 1)
                return num * 4.184;

            return num;
        }

        public double PowerConversion(int index1, int index2, double num)
        {
            if (index1 == 0 && index2 == 1)
                return num * 1000;
            if (index1 == 1 && index2 == 0)
                return num / 1000;

            return num;
        }

        public double PressureConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
                switch (index2)
                {
                    case (1):
                        return num * 1.013;
                    case (2):
                        return num * 101325;
                }

            if (index1 == 1)
                switch (index2)
                {
                    case (0):
                        return num / 1.013;
                    case (2):
                        return num * 100000;
                }

            if (index1 == 2)
                switch (index2)
                {
                    case (0):
                        return num / 101325;
                    case (1):
                        return num / 100000;
                }
            return num;
        }

        public double SpeedConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
                switch (index2)
                {
                    case (1):
                        return num * 100;
                    case (2):
                        return num / 27.778;
                    case (3):
                        return num / 34300;

                }

            if (index1 == 1)
                switch (index2)
                {
                    case (0):
                        return num * 100;
                    case (2):
                        return num * 3.6;
                    case (3):
                        return num * 343;

                }

            if (index1 == 2)
                switch (index2)
                {
                    case (0):
                        return num * 27.778;
                    case (1):
                        return num / 3.6;
                    case (3):
                        return num / 1235;

                }

            if (index1 == 3)
                switch (index2)
                {
                    case (0):
                        return num * 34300;
                    case (1):
                        return num * 343;
                    case (2):
                        return num * 1235;

                }
            return num;
        }

        public double TemperatureConversion(int index1, int index2, double num)
        {
            if (index1 == 0)
                switch (index2)
                {
                    case (1):
                        return (num * 9 / 5) + 32;
                    case (2):
                        return num + 273.15;
                }
            else if (index1 == 1)
                switch (index2)
                {
                    case (0):
                        return (num - 32) * 5 / 9;
                    case (2):
                        return (num - 32) * 5 / 9 + 273.15;
                }
            else if (index1 == 2)
                switch (index2)
                {
                    case (0):
                        return num - 273.15;
                    case (1):
                        return (num - 273.15) * 9 / 5 + 32;
                }
            return num;
        }


    }
}
