using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLibrary
{
    public class TestCount : ITestCount
    {
        private int TstCounter { get; set; }

        public void IncreaseCount()
        {
            TstCounter++;
        }

        public int GetCounter()
        {
            return TstCounter;
        }

        public TestCount()
        {
            TstCounter = 0;
        }
    }
}
