using System;
using System.Collections.Generic;

class Example
{
    struct dt
    {
        public string s1 { get; set; }
        public string s2 { get; set; }
    }
    public static void Main()
    {
     
        Queue<dt> numbers = new Queue<dt>();
        numbers.Enqueue(new dt { s1 = "1" });
        numbers.Enqueue(new dt { s1 = "2" });
        numbers.Enqueue(new dt { s1 = "3" });
        numbers.Enqueue(new dt { s1 = "4" });
        numbers.Enqueue(new dt { s1 = "5" });

        // A queue can be enumerated without disturbing its contents.
        for (dt number in numbers)
        {
            Console.WriteLine(number);
            if (number.s1 == "3")
                )number.s2 = "3";
        }
        
        Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
        string st = numbers.Dequeue();
        Console.WriteLine("Peek at next item to dequeue: {0}",
            numbers.Peek());
        Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

        // Create a copy of the queue, using the ToArray method and the
        // constructor that accepts an IEnumerable<T>.
        Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

        Console.WriteLine("\nContents of the first copy:");
        foreach (string number in queueCopy)
        {
            Console.WriteLine(number);
        }

        // Create an array twice the size of the queue and copy the
        // elements of the queue, starting at the middle of the 
        // array. 
        string[] array2 = new string[numbers.Count * 2];
        numbers.CopyTo(array2, numbers.Count);

        // Create a second queue, using the constructor that accepts an
        // IEnumerable(Of T).
        Queue<string> queueCopy2 = new Queue<string>(array2);

        Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
        foreach (string number in queueCopy2)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}",
            queueCopy.Contains("four"));

        Console.WriteLine("\nqueueCopy.Clear()");
        queueCopy.Clear();
        Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);
    }
}