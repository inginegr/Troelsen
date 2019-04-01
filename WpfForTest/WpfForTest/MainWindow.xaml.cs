using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
 

namespace WpfForTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static StoreDB storeDB = new StoreDB();
        public static StoreDB GetStore { get => storeDB; }


        public MainWindow()
        {            
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            if(Int32.TryParse(InpText.Text,out ID))
            {
                try
                {
                    if ((Button)sender == Get)
                        mgrid.DataContext = GetStore.GetProduct(ID);
                    else if ((Button)sender == Update)
                        GetStore.UpdateProduct((Product)mgrid.DataContext, ID);

                        
                }
                catch
                {
                    MessageBox.Show("Error after get product");
                }
            }
            else
            {
                MessageBox.Show("False ID");
            }
        }
    }

    public class StoreDB
    {
        private string connectToDB = ConfigurationManager.ConnectionStrings["srv"].ConnectionString;

        public Product GetProduct(int ID)
        {
            SqlConnection con = new SqlConnection(connectToDB);
            SqlCommand cmd = new SqlCommand($@"SELECT * FROM Products WHERE ProductID={ID}", con);
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@ProductID", ID);

            try
            {
                con.Open();
                SqlDataReader read = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (read.Read())
                {                    
                    Product product = new Product((string)read["ModelNumber"], (string)read["ModelName"], (int)read["UnitCost"], (string)read["Description"]);
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateProduct(Product prod, int ID)
        {
            SqlConnection con = new SqlConnection(connectToDB);
            SqlCommand cmd = new SqlCommand($@"UPDATE Products SET ModelNumber={prod.ModelNumber}, ModelName={prod.ModelName}, UnitCost={prod.UnitCost}, Description={prod.Description} WHERE ProductID={ID}", con);
            try
            {
                con.Open();
                SqlDataReader read = cmd.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Product
    {
        private string modelNumber;
        public string ModelNumber
        {
            get => modelNumber;
            set => modelNumber = value;
        }

        private string modelName;
        public string ModelName
        {
            get => modelName;
            set => modelName = value;
        }

        private decimal unitCost;
        public decimal UnitCost
        {
            get => unitCost;
            set => unitCost = value;
        }

        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            Description = description;
            UnitCost = unitCost;
        }
    }
}
