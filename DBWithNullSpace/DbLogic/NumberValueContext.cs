namespace DbLogic
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using global::DbLogic.Entities;
    using global::DbLogic.Initializers;


    class NumberValueContext : DbContext
    {
        public DbSet<NumberValueEntity> NumberValue { get; set; }


        public NumberValueContext() : this(null) { }

        public NumberValueContext(string connectionString) : base($"name={connectionString}")
        {
            Database.SetInitializer<NumberValueContext>(new NumberValueWithEmptyStringsInitialize());
        }
    }
}
