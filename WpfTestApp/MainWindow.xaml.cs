using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfTestApp.Models;



namespace DataParallelismWithForEach
{
    public class fr
    {
        public string st { get; set; }

        public fr()
        {
            st = "Hello";
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
            cboCars.ItemsSource = lst;
            gf = new fr();
            this.grd.DataContext = this;
        }

        private void BtnAddCar_OnClick(object sender, RoutedEventArgs e)
        {
            var maxCount = lst?.Max(x => x.CarId) ?? 0;
            lst?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie" });
        }

        private void BtnChangeColor_OnClick(object sender, RoutedEventArgs e)
        {
            lst.First(x => x.CarId == ((Inventory)cboCars.SelectedItem)?.CarId).Color = "Pink";
        }
    }
}