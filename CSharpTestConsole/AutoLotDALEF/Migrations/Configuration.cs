namespace AutoLotDALEF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations.Schema;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDALEF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoLotDALEF.AutoLotEntities context)
        {
            var custumers = new List<Customer>
            {
                new Customer{FirstName="Billy", LastName="Bones"},
                new Customer{FirstName="James", LastName="Flint"},
                new Customer{FirstName="Capitan", LastName="Vane"},
                new Customer{FirstName="Lord", LastName="Guttry"},
                new Customer{FirstName="James", LastName="Rackham"}
            };
            custumers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));

            var inventories = new List<Inventory>
            {
                new Inventory{Make="Honda", Color="Green", PetName="CR-V"},
                new Inventory{Make="Suzuki", Color="White", PetName="Jimny"},
                new Inventory{Make="Lada", Color="Black", PetName="Niva"},
                new Inventory{Make="Mitsubishi", Color="Red", PetName="Junior"},
                new Inventory{Make="Jeep", Color="Blue", PetName="Charokee"},
                new Inventory{Make="Suzuki", Color="Jellow", PetName="Samurai"},
                new Inventory{Make="Lada", Color="Blue", PetName="Niva"},
                new Inventory{Make="Chevrolet", Color="Black", PetName="Niva"},
                new Inventory{Make="UAZ", Color="Green", PetName="Hunter"},
                new Inventory{Make="UAZ", Color="White", PetName="Patriot"}
            };
            context.Inventories.AddOrUpdate(x => new { x.Color, x.Make, x.PetName }, inventories.ToArray());

            var orders = new List<Order>
            {
                new Order{ Car=inventories[0], Customer=custumers[0] },
                new Order{ Car=inventories[1], Customer=custumers[1] },
                new Order{ Car=inventories[2], Customer=custumers[2] },
                new Order{ Car=inventories[3], Customer=custumers[3] },
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarID, c.CustomerID }, x));

            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new CreditRisk
                {
                    Id = custumers[4].Id,
                    FirstName = custumers[4].FirstName,
                    LastName = custumers[4].LastName
                }
            );
        }
    }
}
