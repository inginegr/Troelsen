using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WpfTestApp.Models;
using System.Windows.Controls;
using System.Windows.Input;
using Google.Apis.Discovery;
using Google.Apis.Services;
using System.Threading.Tasks;
using System;
using System.Windows.Media.Animation;

namespace DataParallelismWithForEach
{
    public class fr
    {
        public string st { get; set; }
        public double hgt { get; set; }

        public fr()
        {
            st = "Hello";
            hgt = 400;
        }
    }
    public partial class MainWindow : Window
    {
        public fr frd;
        public fr gf { get { return this.frd; } set { this.frd = value; } }

        readonly ObservableCollection<Inventory> lst = new ObservableCollection<Inventory>();

        public MainWindow()
        {
            
            InitializeComponent();
            lst.Add(new Inventory { CarId = 0, Color = "Black", Make = "Volvo", PetName = "FX-40", IsChanged=false });
            lst.Add(new Inventory { CarId = 1, Color = "Blue", Make = "Suzuki", PetName = "Jimny", IsChanged=false });
            
            this.DataContext = this;

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation ANI = new DoubleAnimation();
            ANI.From = 50;
            ANI.To = 100;
            ANI.Duration = TimeSpan.FromSeconds(1);
            fv.BeginAnimation(Button.WidthProperty, ANI);
        }
    }
}