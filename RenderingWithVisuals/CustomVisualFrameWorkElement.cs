using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;


namespace RenderingWithVisuals
{
    class CustomVisualFrameWorkElement : FrameworkElement
    {
        VisualCollection theVisuals;

        public CustomVisualFrameWorkElement()
        {
            theVisuals = new VisualCollection(this);
            theVisuals.Add(AddRect());
            theVisuals.Add(AddCircle());

            this.MouseDown += MyVisualHost_MouseDown;
        }

        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            using(DrawingContext drarCont = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drarCont.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }

        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            using(DrawingContext drawCont = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawCont.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }

        protected override int VisualChildrenCount
        {
            get { return theVisuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return theVisuals[index];
        }

        void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition((UIElement)sender);

            VisualTreeHelper.HitTest(this, null,
                new HitTestResultCallback(myCallBack), new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior myCallBack(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Transform == null)
                {
                    ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Transform = null;
                }
            }

            return HitTestResultBehavior.Stop;
        }
    }
}
