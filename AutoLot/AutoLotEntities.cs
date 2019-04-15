namespace AutoLot
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

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
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
