namespace AutoLotDALEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order : EntityBase
    {        
        public int CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }

        public int CarID { get; set; }
        [ForeignKey(nameof(CarID))]
        public virtual Inventory Car { get; set; }

    }
}
