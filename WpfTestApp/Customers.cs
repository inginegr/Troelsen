namespace WpfTestApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustID { get; set; }

        [StringLength(30)]
        public string CustName { get; set; }

        [StringLength(30)]
        public string CustLastName { get; set; }

        public int? GoodsID { get; set; }

        public int? GoodsNum { get; set; }
    }
}
