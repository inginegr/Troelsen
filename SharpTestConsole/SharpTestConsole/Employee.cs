using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public float Pay { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
    class Manager : Employee
    {
        public int StockOptions { get; set; }
        public Manager (string fullName,int age, int empID, float currPay, string ssn,int numpOfOpts)
        {
            ID = empID;
            Age = age;
            Name = fullName;
            Pay = currPay;
            SocialSecurityNumber = ssn;
        }
    }

    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }
    }
}
