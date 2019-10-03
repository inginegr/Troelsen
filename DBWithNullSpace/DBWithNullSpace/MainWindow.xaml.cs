using System.Windows;
using DBWithNullSpace.TaskLogic;


namespace DBWithNullSpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseOperations dbo = null;

        public MainWindow()
        {
            InitializeComponent();
            
            dbo = new DataBaseOperations(this.LogBox);
        }

        private void ExcludeEmptyStrings_Click(object sender, RoutedEventArgs e)
        {
            dbo.FillEmptyStrings();
        }

        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            dbo.GetData(this.lbDbContent);
        }
    }
}
