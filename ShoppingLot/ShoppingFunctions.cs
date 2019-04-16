using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ShoppingLot
{
    public class ShoppingFunctions
    {
        public ShoppingFunctions()
        {
            Database.SetInitializer<Entities>(new MyDataInitializer());
            Entities ent = new Entities();
            ent.Database.Initialize(true);
        }
        
    }
}
