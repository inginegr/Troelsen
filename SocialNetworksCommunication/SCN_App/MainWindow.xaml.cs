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
using System.ComponentModel;



namespace SCN_App
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HandleClass localHandle = new HandleClass();

        private string tokenString = String.Empty;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaveToken_Click(object sender, RoutedEventArgs e)
        {
            localHandle.SaveKeySafely(this.InputTextBox.Text);
        }

        private void LoadToken_Click(object sender, RoutedEventArgs e)
        {
            tokenString = localHandle.LoadToken();
        }
    }
}
