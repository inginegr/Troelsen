using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTestConsole;

namespace SharpTestConsole
{
    class Radio
    {
        public void TurnOn( bool on )
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}",
            FirstName, LastName, Age);
        }
        public class PeopleCollection : IEnumerable
        {
            private ArrayList arPeople = new ArrayList();
            // Приведение для вызывающего кода.
            public Person GetPerson(int pos)
            { return (Person)arPeople[pos]; }
            // Вставка только объектов Person.
            public void AddPerson(Person p)
            { arPeople.Add(p); }
            public void ClearPeople()
            { arPeople.Clear(); }
            public int Count
            { get { return arPeople.Count; } }
            // Поддержка перечисления с помощью foreach.
            IEnumerator IEnumerable.GetEnumerator()
            { return arPeople.GetEnumerator(); }
        }
    }
}
