using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormBinding
{
    public class Car
    {
        public int ID { get; set; }
        public string PetName { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
