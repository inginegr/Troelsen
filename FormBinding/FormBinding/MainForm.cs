using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoLotDisconnectedLayer;
using System.Configuration;


namespace FormBinding
{
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "inventoryDataSet.Inventory". При необходимости она может быть перемещена или удалена.
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);

        }

        private void inventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
