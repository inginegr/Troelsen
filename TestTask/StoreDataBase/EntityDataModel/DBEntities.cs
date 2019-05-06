using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;

namespace StoreDataBase.EntityDataModel
{
    partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=StoreDataBase")
        {
        }

        // Сущности
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Buyers> Byuers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().Property(e => e.GoodsName).IsFixedLength();

            modelBuilder.Entity<Buyers>().Property(e => e.BuyerName).IsFixedLength();
        }
    }

    // Инициализируем БД, удаляя ее, затем создавая заново, 
    class InitialiseGoods : DropCreateDatabaseAlways<DBEntities>
    {
        protected override void Seed(DBEntities context)
        {
            List<Goods> gds = new List<Goods>();
            gds.Add(new Goods { GoodsName = "Some Order", GoodsBalance = 100 });
            context.Goods.AddOrUpdate(x => new { x.GoodsName, x.GoodsBalance }, gds.ToArray());

            base.Seed(context);
        }
    }

    // Модель товаров
    partial class Goods
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsId { get; set; } // Идентефикационный номер товара

        [StringLength(10)]
        public string GoodsName { get; set; } // Наименование товара

        public int? GoodsBalance { get; set; } // Остаток товара
    }

    // Модель покупателей
    partial class Buyers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerID { get; set; }

        [StringLength(50)]
        public string BuyerName { get; set; }

        public Byte BuyerNumberOfOrders { get; set; } // Количество товаров, заказанных покупателем
    }
}
