using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using System.Windows.Forms;


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
            txtInventory.Text = LinqToXMLObjectModel.GetXmlInventory().ToString();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "inventoryDataSet.Inventory". При необходимости она может быть перемещена или удалена.
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinqToXMLObjectModel.InsertNewElement(txtMake.Text, txtColor.Text, txtPetName.Text);

            txtInventory.Text = LinqToXMLObjectModel.GetXmlInventory().ToString();
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            LinqToXMLObjectModel.LookUpColorsForMake(txtMakeToLookup.Text);
        }
    }
}
