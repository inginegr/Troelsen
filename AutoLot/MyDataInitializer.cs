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
            var customers = new List<Customers>
            {
                new Customers {FirstName = "Dave", LastName = "Brenner"},
                new Customers {FirstName = "Matt", LastName = "Walton"},
                new Customers {FirstName = "Steve", LastName = "Hagen"},
                new Customers {FirstName = "Pat", LastName = "Walton"},
                new Customers {FirstName = "Bad", LastName = "Customer"},
            }; 
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));

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
        }
    }
}
