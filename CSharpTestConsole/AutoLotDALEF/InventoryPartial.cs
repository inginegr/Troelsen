using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALEF
{
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{CarID} \t {Make} \t {Color} \t {PetName}";
        }

        [NotMapped]
        public string MakeColor => $"{Make}  ({Color})";
    }

    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var custumers = new List<Customer>
            {
                new Customer{CustID=0,FirstName="Billy", LastName="Bones"},
                new Customer{CustID=2,FirstName="James", LastName="Flint"},
                new Customer{CustID=3,FirstName="Capitan", LastName="Vane"},
                new Customer{CustID=4,FirstName="Lord", LastName="Guttry"},
                new Customer{CustID=1,FirstName="James", LastName="Rackham"}
            };
            custumers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.CustID, c.FirstName, c.LastName }, x));

            var inventories = new List<Inventory>
            {
                new Inventory{CarID=0, Make="Honda", Color="Green", PetName="CR-V"},
                new Inventory{CarID=2, Make="Suzuki", Color="White", PetName="Jimny"},
                new Inventory{CarID=3, Make="Lada", Color="Black", PetName="Niva"},
                new Inventory{CarID=4, Make="Mitsubishi", Color="Red", PetName="Junior"},
                new Inventory{CarID=5, Make="Jeep", Color="Blue", PetName="Charokee"},
                new Inventory{CarID=6, Make="Suzuki", Color="Jellow", PetName="Samurai"},
                new Inventory{CarID=7, Make="Lada", Color="Blue", PetName="Niva"},
                new Inventory{CarID=8, Make="Chevrolet", Color="Black", PetName="Niva"},
                new Inventory{CarID=9, Make="UAZ", Color="Green", PetName="Hunter"},
                new Inventory{CarID=1, Make="UAZ", Color="White", PetName="Patriot"}
            };
            context.Inventories.AddOrUpdate(x => new { x.CarID, x.Color, x.Make, x.PetName }, inventories.ToArray());

            var orders = new List<Order>
            {
                new Order{OrderID=1, CarID=3, CustID=5},
                new Order{OrderID=2, CarID=1, CustID=2},
                new Order{OrderID=3, CarID=2, CustID=3},
                new Order{OrderID=4, CarID=9, CustID=1},
                new Order{OrderID=5, CarID=7, CustID=4},
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarID, c.CustID, c.OrderID }, x));

            context.CreditRisks.AddOrUpdate(x => new { x.CustID, x.FirstName, x.LastName },
                new CreditRisk
                {
                    CustID = custumers[4].CustID,
                    FirstName = custumers[4].FirstName,
                    LastName = custumers[4].LastName
                }
            );
        }
    }
}
