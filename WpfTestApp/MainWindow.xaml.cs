using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Reflection;
using System.Xml;
using System.Text;
using System.Windows.Markup;
using WpfTestApp;
using System.Linq;

namespace DataParallelismWithForEach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Entities ent = new Entities())
            {
                try
                {
                    Products pr = new WpfTestApp.Products() {ProductID=int.Parse(PrId.Text), ModelName = MName.Text, Description = Descr.Text, ModelNumber = Mnumber.Text, UnitCost=int.Parse(UCost.Text) };
                    ent.Products.Add(pr);
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(Entities ent=new Entities())
            {
                try
                {
                    GRD.Items.Clear();
                    var sel = from item in ent.Products select new { item.ProductID, item.Description, item.ModelNumber };
                    foreach (var p in sel)
                        GRD.Items.Add(p);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (Entities ent = new Entities())
            {
                try
                {
                    var el = ent.Products.Find(int.Parse(PrId.Text));
                    MName.Text = el.ModelName;
                    Mnumber.Text = el.ModelNumber;
                    UCost.Text = el.UnitCost.ToString();
                    Descr.Text = el.Description;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}