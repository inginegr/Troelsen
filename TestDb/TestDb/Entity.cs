namespace TestDb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;

    public partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.Name)
                .IsFixedLength();
        }
    }

    public class InitializeDb : DropCreateDatabaseAlways<Entity>
    {
        protected override void Seed(Entity context)
        {
            List<Goods> gds = new List<Goods>();
            for (int i = 0; i < 10; i++)
                gds.Add(new Goods { ID = i, Name = i.ToString(), Number = i * 3 });

            context.Goods.AddOrUpdate(x => new { x.ID, x.Name, x.Number }, gds.ToArray());

            base.Seed(context);
        }
    }
}
