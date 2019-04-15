namespace WpfTestApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(50)]
        public string ModelNumber { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        [StringLength(50)]
        public string ProductImage { get; set; }

        public int UnitCost { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{this.ProductID}   {this.CategoryID}  {this.ModelName}  {this.ModelNumber}  {this.ProductImage}  {this.UnitCost}  {this.Description}";
        }
    }
}
