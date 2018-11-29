using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using System.Windows.Forms;


namespace FormBinding
{
    class LinqToXMLObjectModel
    {
        public static XDocument GetXmlInventory()
        {
            try
            {
                XDocument inventoryDoc = XDocument.Load("Inventory.xml");
                return inventoryDoc;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void InsertNewElement(string make, string color, string petName)
        {
            XDocument inventoryDoc = XDocument.Load("Inventory.xml");

            Random r = new Random();

            XElement newElement = new XElement("Car", new XAttribute("ID", r.Next(50000)),
                new XElement("Color", color),
                new XElement("Make", make),
                new XElement("PetName", petName));

            inventoryDoc.Descendants("Inventory").First().Add(newElement);

            inventoryDoc.Save("Inventory.xml");
        }
        public static void LookUpColorsForMake(string make)
        {
            XDocument inventoryDoc = XDocument.Load("Inventory.xml");

            var makeInfo = from car in inventoryDoc.Descendants("Car")
                           where (string)car.Element("Make") == make
                           select car.Element("Color").Value;

            string data = string.Empty;

            foreach (var item in makeInfo.Distinct())
                data += string.Format("- {0}\n", item);

            MessageBox.Show(data, string.Format("{0} colors:", make));
        }
    }
}
