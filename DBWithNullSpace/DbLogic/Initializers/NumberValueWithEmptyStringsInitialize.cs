using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DbLogic.Entities;

namespace DbLogic.Initializers
{
    /// <summary>
    /// Initialize database with empty 'value' rows
    class NumberValueWithEmptyStringsInitialize : DropCreateDatabaseAlways<NumberValueContext>
    {
        protected override void Seed(NumberValueContext NVContext)
        {
            List<NumberValueEntity> values = new List<NumberValueEntity>
            {
                new NumberValueEntity() { NumberId = 1, Value = "" },
                new NumberValueEntity() { NumberId = 2, Value = "собака" },
                new NumberValueEntity() { NumberId = 3, Value = "кошка" },
                new NumberValueEntity() { NumberId = 4, Value = "" },
                new NumberValueEntity() { NumberId = 5, Value = "" },
                new NumberValueEntity() { NumberId = 6, Value = "" },
                new NumberValueEntity() { NumberId = 7, Value = "" },
                new NumberValueEntity() { NumberId = 8, Value = "" },
                new NumberValueEntity() { NumberId = 9, Value = "слон" },
                new NumberValueEntity() { NumberId = 10, Value = "" },
                new NumberValueEntity() { NumberId = 11, Value = "" },
                new NumberValueEntity() { NumberId = 12, Value = "утка" }
            };

            NVContext.NumberValue.AddRange(values);

            base.Seed(NVContext);
        }
    }
}