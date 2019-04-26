namespace TempConsole
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Buyers> Byuers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().Property(e => e.GoodsName).IsFixedLength();

            modelBuilder.Entity<Buyers>().Property(e => e.BuyerName).IsFixedLength();
        }
    }

    class InitialiseGoods: DropCreateDatabaseAlways<Entity>
    {
        protected override void Seed(Entity context)
        {
            List<Goods> gds = new List<Goods>();
            gds.Add(new Goods { GoodsName = "SuperGoods", GoodsBalance = 100 });
            context.Goods.AddOrUpdate(x => new { x.GoodsName, x.GoodsBalance }, gds.ToArray());

            base.Seed(context);
        }
    }

}
