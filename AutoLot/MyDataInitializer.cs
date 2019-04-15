using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot
{
    public class MyDataInitializer:DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {            
            context.Customers.AddOrUpdate(x => new { x.FirstName, x.LastName}, new Customers
            {
                CustID=0,
                LastName = "one",
                FirstName = "one1"
            },
            new Customers
            {
                CustID=1,
                FirstName = "two1",
                LastName = "two2"
            });
            context.SaveChanges();
            //var customers = new List<Customers>
            //{
            //    new Customers {CustID=0, FirstName = "Dave", LastName = "Brenner"},
            //    new Customers {CustID=1, FirstName = "Matt", LastName = "Walton"},
            //    new Customers {CustID=2, FirstName = "Steve", LastName = "Hagen"},
            //    new Customers {CustID=3, FirstName = "Pat", LastName = "Walton"},
            //    new Customers {CustID=4, FirstName = "Bad", LastName = "Customer"},
            //}; 
            //customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));
            //context.SaveChanges();
            //var cars = new List<Inventory>
            //{
            //    new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
            //    new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
            //    new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
            //    new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
            //    new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
            //    new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
            //    new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
            //    new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
            //    new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            //};
            //context.Inventory.AddOrUpdate(x => new { x.Make, x.Color, x.PetName }, cars.ToArray());
            //context.SaveChanges();
        }
    }
}
