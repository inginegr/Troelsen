﻿using System;
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
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            Database.SetInitializer(new MyDataInitializer());
            AutoLotEntities ent = new AutoLotEntities();
            
            foreach(Customers cs in ent.Customers)
                GRD.Items.Add($"{cs.CustID}   {cs.FirstName}   {cs.LastName}");
        }
    }    
}