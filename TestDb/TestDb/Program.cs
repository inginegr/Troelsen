using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new InitializeDb());


            Entity ent = new Entity();

            Goods gd = ent.Goods.Find(3);

            foreach (Goods g in ent.Goods)
                Console.WriteLine($"{g.ID}   {g.Name}    {g.Number}");

            Console.ReadLine();
        }
    }
}
