using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    public class Point<T>
    {
        private T xPos;
        private T yPos;

        public Point (T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }

        public T X
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", xPos, yPos);
        }

        public void Resetpoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}
