using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestApp;
using System.Windows;
using ShoppingLot;

namespace DataParallelismWithForEach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
            ShoppingFunctions sd = new ShoppingFunctions();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}