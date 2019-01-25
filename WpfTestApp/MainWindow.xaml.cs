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

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            GetProc();
        }
        void GetProc()
        {
            string FilesPath = @"C:\Users\Public\Pictures\Sample Pictures";
            string NewPath = @"C:\Users\Public\Pictures\Sample Pictures\NewPic";
            string[] msFiles = Directory.GetFiles(FilesPath, "*.jpg");
            Directory.CreateDirectory(@"C:\Users\Public\Pictures\Sample Pictures\NewPic");
            Parallel.ForEach(msFiles, (s)=>
            {
                string st = Path.GetFileName(s);
                using(Bitmap bp=new Bitmap(s))
                {
                    bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bp.Save(Path.Combine(NewPath, st));
                    this.Dispatcher.Invoke((Action)delegate
                    {
                      //  lock (new object())
                      //  {
                            this.Title = $"Processing {st} on thread {Thread.CurrentThread.ManagedThreadId}";
                      //  }
                    });
                    
                    
                }
            }
            );
        }
    }
}
