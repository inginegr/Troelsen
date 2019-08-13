namespace Summary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public int id { get; set; }

        public string Text { get; set; }

        public bool? IsRead { get; set; }

        public override string ToString()
        {
            return id.ToString() + " " + Text.ToString() + "\n";
        }
    }
}
