using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;



namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cnt = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }        

        private void MenuItem_MouseEnter_Exit(object sender, MouseEventArgs e)
        {

        }

        private void MenuItem_MouseLeave_Exit(object sender, MouseEventArgs e)
        {
            
        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_MouseEnter_Tools(object sender, MouseEventArgs e)
        {

        }

        private void MenuItem_MouseLeav_Tools(object sender, MouseEventArgs e)
        {

        }

        private void MenuItem_Click_Tools(object sender, RoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            int y = 8;

            if (y > 7)
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
            
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog { Filter = "Text Files |*.txt" };
            if (opf.ShowDialog() == true)
            {
                string str = File.ReadAllText(opf.FileName);
            }
        }

        private void EllipseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hello from ellipse");
            e.Handled = false;
        }

        private void Bla(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}
