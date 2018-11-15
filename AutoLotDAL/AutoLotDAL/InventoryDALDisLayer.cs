using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDisconnectedLayer
{
    public class InventoryDALDisLayer
    {
        private string cnString = string.Empty;
        private SqlDataAdapter dAdapt = null;

        public InventoryDALDisLayer(string constr)
        {
            cnString = constr;

            ConfigureAdapter(out dAdapt);
        }
        private void ConfigureAdapter(out SqlDataAdapter dAdapt)
        {
            int x = 6;
            Console.WriteLine(x);
        }
    }
}
