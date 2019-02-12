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
        CancellationTokenSource cnt = new CancellationTokenSource();

        public MainWindow()
        {
            //InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            cnt.Cancel();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => GetProc());
        }
        void GetProc()
        {
            ParallelOptions parop = new ParallelOptions();
            parop.CancellationToken = cnt.Token;
            parop.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            string FilesPath = @"C:\Users\Public\Pictures\Sample Pictures";
            string NewPath = @"C:\Users\Public\Pictures\Sample Pictures\NewPic";
            string[] msFiles = Directory.GetFiles(FilesPath, "*.jpg");
            Directory.CreateDirectory(@"C:\Users\Public\Pictures\Sample Pictures\NewPic");

            try
            {
                Parallel.ForEach(msFiles, parop, (s) =>
                    {
                        parop.CancellationToken.ThrowIfCancellationRequested();
                        string st = Path.GetFileName(s);
                        using (Bitmap bp = new Bitmap(s))
                        {
                            bp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bp.Save(Path.Combine(NewPath, st));
                            this.Dispatcher.Invoke((Action)delegate { this.Title = $"Processing {st} on thread {Thread.CurrentThread.ManagedThreadId}"; });
                        }
                    }
                    );
                this.Dispatcher.Invoke((Action)delegate { this.Title = "Done"; });
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke((Action)delegate { this.Title = ex.Message; });
            }
        }
    }
}
