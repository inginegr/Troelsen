using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media;


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
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        { 
            string mcolor = (this.comboColors.SelectedItem as ComboBoxItem)?.Content.ToString();

            this.MyInkCanvas.DefaultDrawingAttributes.Color =  (Color)ColorConverter.ConvertFromString(mcolor);
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
}
