using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media;
using System;



namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            MyConv cnv = new MyConv();            
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        { 
            string mcolor = (this.comboColors.SelectedItem as ComboBoxItem)?.Content.ToString();
            

           // this.MyInkCanvas.DefaultDrawingAttributes.Color =  (Color)ColorConverter.ConvertFromString(mcolor);
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch((sender as RadioButton)?.Name.ToString())
            {
                case "inkRadio":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "eraseRadio":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "selectRadio":                    
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }
    }

    public class MyConv : IValueConverter
    {
        public object Convert(object value, Type targettype, object param, System.Globalization.CultureInfo ci)
        {
            double v = (double)value;
            return (int)v;
        }

        public object ConvertBack(object value, Type targettype, object param, System.Globalization.CultureInfo ci)
        {
            return value;
        }
    }
}
