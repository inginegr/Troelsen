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
using System.Windows.Controls.Primitives;
using System.Configuration;
using System.Data;
using WpfTestApp.Models;



namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Inventory> lst = new List<Inventory>();
        public MainWindow()
        {
            InitializeComponent();
            lst.Add(new Inventory { CarId = 0, Color = "Black", Make = "Volvo", PetName = "FX-40" });
            lst.Add(new Inventory { CarId = 1, Color = "Blue", Make = "Suzuki", PetName = "Jimny" });
            cboCars.ItemsSource = lst;
        }

        private void BtnAddCar_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnChangeColor_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
