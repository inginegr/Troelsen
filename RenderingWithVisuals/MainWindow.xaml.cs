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

namespace RenderingWithVisuals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Windows_Loaded(object sender,RoutedEventArgs e)
        {
            const int TextFontSize = 30;
            FormattedText text = new FormattedText("Hello Visual Layer!", new System.Globalization.CultureInfo("en-us"),
                FlowDirection.LeftToRight, new Typeface(this.FontFamily, FontStyles.Italic, FontWeights.DemiBold,
                FontStretches.UltraExpanded), TextFontSize, Brushes.Green);
            DrawingVisual drawingVisual = new DrawingVisual();
            using(DrawingContext drawCont = drawingVisual.RenderOpen())
            {
                drawCont.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5), new Rect(5, 5, 450, 100), 20, 20);

                drawCont.DrawText(text, new Point(20, 20));
            }
            RenderTargetBitmap bmp = new RenderTargetBitmap(500, 100, 100, 90, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            myImage.Source = bmp; 

        }
    }
}
