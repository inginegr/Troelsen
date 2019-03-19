using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace WpfTestApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public class AppClass
    {
        public string stfr { get; set; }
        public AppClass()
        {
            stfr = "Hello Friend";
        }
    }
    public partial class App : Application
    {
    }
}
