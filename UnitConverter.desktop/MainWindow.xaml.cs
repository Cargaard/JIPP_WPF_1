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
using UnitConverter.Logic;
using UnitConverter.UsageHistory;
using System.Windows.Media.Animation;


namespace UnitConverter.desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int option;
        private IConverter[] converters;
        private IConverterSpecial[] SpecialConverters;
        private bool units;
        public MainWindow()
        {
            this.units = true;
            InitializeComponent();
            converters = new IConverter[]
            {
                new distance(),
                new mass(),
                new temperature(),
            };
            SpecialConverters = new IConverterSpecial[]
            {
                new Time(),
            };
            List<string> holder = new List<string> { };
            for (int i=0; i<converters.Length; ++i)
            {
                holder.Add(converters[i].name);
            }
            for (int i = 0; i < SpecialConverters.Length; ++i)
            {
                holder.Add(SpecialConverters[i].name);
            }
            ChooseConverter.ItemsSource = holder;
        }

        
        /*
         Konwertuj action
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           string inputVal = this.InputTextBox.Text;
            string convName = "";
            string unitTo = null;
            string unitFrom = null;
            string result = null;
            ConvertersHistory history = new ConvertersHistory();
            if (option > converters.Length - 1)
            {
                IConverterSpecial Converter = SpecialConverters[option-converters.Length];
                result = Converter.Convert(inputVal);
                ClockSetup(result);
                OutputTextBlock.Text = result;
                convName = Converter.name;
            }
            else
            {
                decimal val = decimal.Parse(inputVal);
                IConverter converter = converters[option];
                result = (converter.Convert(val, ChooseUnitFrom.SelectedItem as string, ChooseUnitTo.SelectedItem as string)).ToString();
                unitTo = ChooseUnitTo.SelectedItem as string;
                unitFrom = ChooseUnitFrom.SelectedItem as string;
                OutputTextBlock.Text = result;
                convName = converter.name;
            }
            history.AddHistoryToDb(convName, inputVal, result, unitFrom, unitTo);
           
        }

        private void ClockSetup(string time)
        {
            List<string> elementary = time.Split(':').ToList();
            double hour = Double.Parse(elementary[0]);
            elementary[1] = elementary[1].Substring(0,elementary[1].Length - 3);
            double minute = Double.Parse(elementary[1]);
            double hourAngle = 360.00 / 12;
            double minuteAngle = 360.00 / 60.00;
           
            
            RotateTransform rotate = new RotateTransform();
            TransformGroup group = new TransformGroup();
            rotate.Angle = hourAngle*hour+90;
            group.Children.Add(rotate);
            this.hourArrow.RenderTransform = group;


            TransformGroup minutearrowgroup = new TransformGroup();
            RotateTransform minuteArrowRotate = new RotateTransform();
            minuteArrowRotate.Angle = minuteAngle * minute + 90;
            minutearrowgroup.Children.Add(minuteArrowRotate);
            this.minuteArrow.RenderTransform = minutearrowgroup;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            option = ChooseConverter.SelectedIndex;
            if(option>converters.Length-1)
            {
                if (this.units) 
                    ((Storyboard)Resources["Hide"]).Begin();
                 this.units = false;
                return;
            }
            if (!this.units) 
                ((Storyboard)Resources["Show"]).Begin();
            this.units = true;
            Units.Visibility = Visibility.Visible;
            IConverter converter = converters[option];
                List<string> units = converter.units;
                ChooseUnitFrom.ItemsSource = units;
                ChooseUnitTo.ItemsSource = units;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Statistics window = new Statistics();
            window.Show();
        }
    }
}
