using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections;

//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BitmapImage> img = new List<BitmapImage>();
        int imgInd = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BOne_Click(object sender, RoutedEventArgs e)
        {
            //Next
            if (imgInd >= img.Count)
                imgInd = 0;
            MyImg.Source = img[imgInd++];
        }

        private void BTwo_Click(object sender, RoutedEventArgs e)
        {
            //Prev
            if (imgInd < 0)
                imgInd = img.Count - 1;
            MyImg.Source = img[imgInd--];
        }

        private void BThird_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Chrysanthemum.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Desert.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Hydrangeas.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Jellyfish.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Koala.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Lighthouse.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Penguins.jpg")));
                img.Add(new BitmapImage(new Uri($@"{path}\Images\Tulips.jpg")));

                MyImg.Source = img[imgInd];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
