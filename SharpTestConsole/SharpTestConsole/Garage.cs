using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    public class Garage
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 20);
            carArray[2] = new Car("Zippy", 55);
            carArray[3] = new Car("Fred", 34);
        }
    }
}
