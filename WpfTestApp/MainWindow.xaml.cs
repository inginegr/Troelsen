using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLot;
using System.Windows;




namespace DataParallelismWithForEach
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new MyDataInitializer());
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            AutoLotEntities ent = new AutoLotEntities();
            
            foreach(Inventory inv in ent.Inventory)
                GRD.Items.Add($"{inv.CarID}   {inv.Color}   {inv.PetName}");
        }
    }    
}