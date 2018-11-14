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
        }
    }
}
