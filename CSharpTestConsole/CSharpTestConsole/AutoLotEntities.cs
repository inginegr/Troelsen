namespace CSharpTestConsole
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotEntities")
        {
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditRisk>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<CreditRisk>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.Make)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.PetName)
                .IsUnicode(false);
        }
    }
}
