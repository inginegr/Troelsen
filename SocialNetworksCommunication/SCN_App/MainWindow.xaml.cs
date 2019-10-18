using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using SCN_App.Telegram;


namespace SCN_App
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HandleClass localHandle = new HandleClass();

        private string tokenString = String.Empty;

        TelegrammBot tgb = new TelegrammBot();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendCommand_Click(object sender, RoutedEventArgs e)
        {
            localHandle.SendCommand(CommandList);

            //List<string> ls = new List<string>();
            //ls.Add(list);
            Thread.Sleep(1000);
            localHandle.FillData(OutTextBox);
        }

        private void StartListen_Click(object sender, RoutedEventArgs e)
        {
            tgb.StartListenBot();
        }

        private void StopListen_Click(object sender, RoutedEventArgs e)
        {
            tgb.StopListenBot();
        }

        private void SaveToken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                localHandle.SaveKeySafely(this.InputTextBox.Text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadToken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                localHandle.LoadVkLibrary(CommandList);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
