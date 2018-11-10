using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    public class BitmapImage
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpSideDown()
        {
            Console.WriteLine("Drawing upside down...");
        }
    }
    public class SimpleMath
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage nmDelegate;
        public void SetMathHandler(MathMessage target)
        {
            nmDelegate = target;
        }
        public void Add(int x,int y)
        {
            if (nmDelegate != null)
                nmDelegate.Invoke("Adding has completed!", x + y);
        }
    }
}
