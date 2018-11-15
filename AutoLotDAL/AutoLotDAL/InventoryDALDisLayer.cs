using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            dAdapt = new SqlDataAdapter("Select * From Inventory", cnString);
            SqlCommandBuilder sbuild = new SqlCommandBuilder(dAdapt);
        }
        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            dAdapt.Fill(inv);
            return inv;
        }

        public void UpdateInventory(DataTable modtab)
        {
            dAdapt.Update(modtab);
        }
    }
}
