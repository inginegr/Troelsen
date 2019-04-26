namespace TempConsole
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    partial class Goods
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsId { get; set; }

        [StringLength(10)]
        public string GoodsName { get; set; }

        public int? GoodsBalance { get; set; }
    }

    partial class Buyers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerID { get; set; }

        [StringLength(50)]
        public string BuyerName { get; set; }

        public Byte BuyerNumberOfOrders { get; set; }
    }
}
