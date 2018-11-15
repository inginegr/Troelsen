using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBinding
{
    
    public partial class Form1 : Form
    {
        List<Car> listCars = null;
        DataView yugoOnlyView;
        DataTable inventoryTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
            // Заполнить список несколькими автомобилями.
            listCars = new List<Car>
            {
                new Car { ID = 100, PetName = "Chucky", Make = "BMW", Color = "Green" },
                new Car { ID = 101, PetName = "Tiny", Make = "Yugo", Color = "White" },
                new Car { ID = 102, PetName = "Ami", Make = "Jeep", Color = "Tan" },
                new Car { ID = 103, PetName = "Pain Inducer", Make = "Caravan", Color = "Pink" },
                new Car { ID = 104, PetName = "Fred", Make = "BMW", Color = "Green" },
                new Car { ID = 105, PetName = "Sidd", Make = "BMW", Color = "Black" },
                new Car { ID = 106, PetName = "Mel", Make = "Firebird", Color = "Red"  },
                new Car { ID = 107, PetName = "Sarah", Make = "Colt", Color = "Black"  },
            };
            CreateDataTable();
        }
        private void CreateDataTable()
        {
            // Создать схему таблицы.
            DataColumn carIDColumn = new DataColumn("ID", typeof(int));
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn,
                carMakeColumn, carColorColumn, carPetNameColumn });
            // Пройти no List<T> для создания строк.
            foreach (Car c in listCars)
            {
                DataRow newRow = inventoryTable.NewRow();
                newRow["ID"] = c.ID;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                inventoryTable.Rows.Add(newRow);
            }
            // Привязать DataTable к carInventoryGridView.
            carInventoryGridView.DataSource = inventoryTable;
        }

        private void ShowCarsWithGreaterThanN(int n)
        {
            DataRow[] properID;
            properID = inventoryTable.Select(string.Format("ID > {0}", n));
            string strID = null;
            for (int i = 0; i < properID.Length; i++)
            {
                DataRow temp = properID[i];
                strID += temp["PetName"] + "is ID" + temp["ID"] + "\n";
            }
            MessageBox.Show(strID, string.Format("The values with ID greater than {0}", n));
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rowToDelete = inventoryTable.Select(
                    string.Format("ID={0}", int.Parse(txtRowToRemove.Text)));
                rowToDelete[0].Delete();
                inventoryTable.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisplayMakes_Click(object sender, EventArgs e)
        {
            string filterStr = string.Format("Make='{0}'", txtMakeToView.Text);
            DataRow[] makes = inventoryTable.Select(filterStr);
            if (makes.Length == 0)
                MessageBox.Show("Sorry, no cars...", "Selection Error!");
            else
            {
                string strMake = "";
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["ID"] + "\n";
                }
                MessageBox.Show(strMake, string.Format("We have {0} named: ", txtMakeToView.Text));
            }
        }

        private void edtChangeMake_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnChangeMake_Click(object sender, EventArgs e)
        {
            DataRow[] strUpdate = inventoryTable.Select(string.Format("Make='{0}'", edtChangeMake.Text));
            for (int i = 0; i < strUpdate.Length; i++)
            {
                strUpdate[i]["Make"] = "Yugo";
            }
        }

        private void CreateDataView(string from,string to)
        {
            yugoOnlyView = new DataView(inventoryTable);
            yugoOnlyView.RowFilter = string.Format("{0} = '{1}'", from, to);
            dataGridYugo.DataSource = yugoOnlyView;
        }

        private void btnShowSub_Click(object sender, EventArgs e)
        {
            CreateDataView(edtShowSubFrom.Text, edtShowSubTo.Text);
        }
    }
}
