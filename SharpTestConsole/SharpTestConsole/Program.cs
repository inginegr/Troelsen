// Класс Calc.cs
using System;
using System.Text;

namespace ConstData
{
    class Employee
    {
        // Поля данных. 
        private string empName;
        private int empID;
        // Новое поле и свойство.
        private int empAge;
        public string FirstName
        {
            get { return FirstName; }
            set{FirstName=value;}
        }
        public string LastName { get; set; }
        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }
        private float currPay;
        // Свойства.
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                else
                    empName = value;
            }
        }
        // Можно было бы добавить дополнительные бизнес-правила для установки
        // этих свойств, но в данном примере в этом нет необходимости.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        // Обновленные конструкторы.
        public Employee() { }
        public Employee(string name, int id, float pay)
            : this(name, 0, id, pay) { }
        public Employee(string nm):this(nm,0,0,0){}
        public Employee(string name, int age, int id, float pay)
        {
            empName = name;
            empID = id;
            empAge = age;
            currPay = pay;
        }
        // Обновленный метод DisplayStats() теперь учитывает возраст.
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("Pay: {0}", currPay);
        }
    }
    // Простой базовый класс. 
    class Manager : Employee
    {
        public int StockOptions { get; set; }
    }
    // MiniVan "является" Саr. 
    class Salesperson : Employee
    {
        public int SalesNumber { get; set; }
        public override string ToString()
        {
            string mystr = string.Format("[First Name: {0}; Last Name: {1}, Age: {2}", FirstName, LastName, Age);
            return mystr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            // Статические члены System.Object.
            Employee p3 = new Employee("Sally");
            Employee p4 = new Employee("Sally");
            Console.WriteLine("P3 and P4 have same state: {0}", object.Equals(p3, p4));
            Console.WriteLine("P3 and P4 are pointing to same object: {0}", object.ReferenceEquals(p3, p4));
            p3.DisplayStats();
            p4.DisplayStats();
            Console.ReadLine();
        }
    }
}