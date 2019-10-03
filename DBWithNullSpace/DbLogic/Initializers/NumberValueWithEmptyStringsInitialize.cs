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
    public class NumberValueWithEmptyStringsInitialize : DropCreateDatabaseAlways<NumberValueContext>
    {
        protected override void Seed(NumberValueContext NVContext)
        {
            NumberValueEntity nv2 = new NumberValueEntity() { NumberId = 2, Value = "собака" };
            NumberValueEntity nv3 = new NumberValueEntity() { NumberId = 2, Value = "собака" };
            NumberValueEntity nv9 = new NumberValueEntity() { NumberId = 2, Value = "собака" };
            NumberValueEntity nv12 = new NumberValueEntity() { NumberId = 2, Value = "собака" };

            NVContext.NumberValue.Add(nv2);
            NVContext.NumberValue.Add(nv3);
            NVContext.NumberValue.Add(nv9);
            NVContext.NumberValue.Add(nv12);

            base.Seed(NVContext);
        }
    }
}