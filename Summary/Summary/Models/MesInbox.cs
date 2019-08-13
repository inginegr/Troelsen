namespace Summary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MesInbox : DbContext
    {
        public MesInbox()
            : base("name=MesInbox")
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
