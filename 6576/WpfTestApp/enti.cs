namespace WpfTestApp
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class enti : DbContext
    {
        public enti()
            : base("name=enti")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }

    public class MyDataInitializer : DropCreateDatabaseAlways<enti>
    {
        protected override void Seed(enti context)
        {
            var custs = new List<Customers>()
            {
                new Customers{LastName="asdasd", FirstName="1231231"},
                new Customers{LastName="asdasd", FirstName="1231231"},
                new Customers{LastName="asdasd", FirstName="1231231"}
            };
            context.Customers.AddOrUpdate(x => new { x.LastName, x.FirstName }, custs.ToArray());
            context.SaveChanges();
        }
    }
}
