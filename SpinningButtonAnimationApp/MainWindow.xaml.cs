using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;


namespace SpinningButtonAnimationApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isSpinning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                DoubleAnimation dblAnim = new DoubleAnimation();

                dblAnim.Completed += (o, s) => { isSpinning = false; };
                dblAnim.From = 0;
                dblAnim.To = 360;

                RotateTransform rt = new RotateTransform(0,50,25);
                btnSpinner.RenderTransform = rt;

                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }

        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            dblAnim.AutoReverse = true;
            dblAnim.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
        }
    }
}
