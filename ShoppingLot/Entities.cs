namespace ShoppingLot
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=ShoppingConnection")
        {

        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.CatName)
                .IsFixedLength();

            modelBuilder.Entity<Customers>()
                .Property(e => e.CustName)
                .IsFixedLength();

            modelBuilder.Entity<Customers>()
                .Property(e => e.CustLastName)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Description)
                .IsFixedLength();
        }
    }

    public class MyDataInitializer : DropCreateDatabaseAlways<Entities>
    {
        protected override void Seed(Entities context)
        {
            List<Categories> ctg = new List<Categories>
            {
                new Categories{CategoryID=0, CatName="Meat"},
                new Categories{CategoryID=1, CatName="Milky"},
                new Categories{CategoryID=2, CatName="Auto"},
                new Categories{CategoryID=3, CatName="Sweet"}
            };
            context.Categories.AddOrUpdate(x => new { x.CategoryID, x.CatName }, ctg.ToArray());

            List<Store> str = new List<Store>
            {
                new Store{ GoodsID=0, Category="Meat", Cost=350, Name="Sausage", Remain=43, Description="The meat inside of cover"},
                new Store{ GoodsID=1, Category="Meat", Cost=450, Name="Carbonado", Remain=67, Description="The preassured meat inside of cover"},
                new Store{ GoodsID=2, Category="Meat", Cost=350, Name="Beef", Remain=243, Description="Clear meat of bacon"},
                new Store{ GoodsID=3, Category="Milk", Cost=45, Name="Milk", Remain=433, Description="Clear milk of cow"},
                new Store{ GoodsID=4, Category="Milk", Cost=54, Name="Kefir", Remain=234, Description="Sour milk"},
                new Store{ GoodsID=5, Category="Sweat", Cost=150, Name="Wafer", Remain=123, Description="The sweat wafer"},
                new Store{ GoodsID=6, Category="Auto", Cost=950, Name="Oil", Remain=43, Description="The oil for auto"},
                new Store{ GoodsID=7, Category="Sweat", Cost=250, Name="Candy", Remain=83, Description="The sweat candy"},
            };
            context.Store.AddOrUpdate(x => new { x.GoodsID, x.Name }, str.ToArray());

            List<Customers> cst = new List<Customers>
            {
                new Customers{ CustID=0, CustLastName="Bones", CustName="Billy", GoodsID=2, GoodsNum=5 },
                new Customers{ CustID=1, CustLastName="Capitan", CustName="Flint", GoodsID=4, GoodsNum=7 },
                new Customers{ CustID=2, CustLastName="Capitan", CustName="Wane", GoodsID=3, GoodsNum=1 },
                new Customers{ CustID=3, CustLastName="Gray", CustName="Gendalf", GoodsID=7, GoodsNum=6 },
                new Customers{ CustID=4, CustLastName="Mouse", CustName="Mikky", GoodsID=1, GoodsNum=4 },
                new Customers{ CustID=5, CustLastName="Rackham", CustName="Jack", GoodsID=5, GoodsNum=12 },
                new Customers{ CustID=6, CustLastName="Snow", CustName="John", GoodsID=6, GoodsNum=3 },
                new Customers{ CustID=7, CustLastName="Eddward", CustName="Stark", GoodsID=0, GoodsNum=11 },
                new Customers{ CustID=8, CustLastName="Starc", CustName="Sansa", GoodsID=5, GoodsNum=7 },
                new Customers{ CustID=9, CustLastName="Gates", CustName="John", GoodsID=4, GoodsNum=8 },
                new Customers{ CustID=10, CustLastName="Straustrup", CustName="Bjarne", GoodsID=7, GoodsNum=8 }
            };
            context.Customers.AddOrUpdate(x => new { x.CustID, x.CustName }, cst.ToArray());

            context.SaveChanges();

            base.Seed(context);
        }
    }

    public class EntityBase
    {
        [Key]
        public int ID { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
