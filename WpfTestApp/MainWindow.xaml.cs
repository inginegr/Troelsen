using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;
using WpfTestApp.Models;
using System.Windows.Controls;
using System;
using System.Reflection;
using System.Xml;
using System.Text;
using System.Windows.Markup;


namespace DataParallelismWithForEach
{
    public class fr
    {
        public string st { get; set; }
        public double hgt { get; set; }

        public fr()
        {
            st = "Hello";
            hgt = 400;
        }
    }
    public partial class MainWindow : Window
    {
        public fr frd;
        public fr gf { get { return this.frd; } set { this.frd = value; } }

        readonly ObservableCollection<Inventory> lst = new ObservableCollection<Inventory>();

        public MainWindow()
        {            
            InitializeComponent();
            lst.Add(new Inventory { CarId = 0, Color = "Black", Make = "Volvo", PetName = "FX-40", IsChanged=false });
            lst.Add(new Inventory { CarId = 1, Color = "Blue", Make = "Suzuki", PetName = "Jimny", IsChanged=false });
            
            this.DataContext = this;
        }
        
        private void MW_Loaded(object sender, RoutedEventArgs e)
        {
            Type typeControl = typeof(Control);
            List<Type> myTypes = new List<Type>();

            // Ищем все типы в сборке
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeControl) && !type.IsAbstract && type.IsPublic)
                {
                    myTypes.Add(type);
                }

                // отсортируем список
                myTypes.Sort(new TypeComparer());

                lbx.ItemsSource = myTypes;
                lbx.DisplayMemberPath = "Name";
            }
        }

        private void lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get the selected type.
                Type type = (Type)lbx.SelectedItem;

                // Instantiate the type.
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);

                Window win = control as Window;
                if (win != null)
                {
                    // Create the window (but keep it minimized).
                    win.WindowState = System.Windows.WindowState.Minimized;
                    win.ShowInTaskbar = false;
                    win.Show();
                }
                else
                {
                    // Add it to the grid (but keep it hidden).
                    control.Visibility = Visibility.Collapsed;
                    grid.Children.Add(control);
                }

                // Get the template.
                ControlTemplate template = control.Template;

                // Get the XAML for the template.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);

                // Display the template.
                txb.Text = sb.ToString();

                // Remove the control from the grid.
                if (win != null)
                {
                    win.Close();
                }
                else
                {
                    grid.Children.Remove(control);
                }
            }
            catch (Exception err)
            {
                txb.Text = "<< Error generating template: " + err.Message + ">>";
            }
        }
    }

    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}