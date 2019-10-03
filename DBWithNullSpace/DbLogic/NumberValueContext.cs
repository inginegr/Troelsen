namespace DbLogic
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using global::DbLogic.Entities;
    using global::DbLogic.Initializers;


    public class NumberValueContext : DbContext
    {
        public DbSet<NumberValueEntity> NumberValue { get; set; }

        public NumberValueContext() : base("name=NumberValueContext")
        {
            Database.SetInitializer<NumberValueContext>(new NumberValueWithEmptyStringsInitialize());
        }
    }
}