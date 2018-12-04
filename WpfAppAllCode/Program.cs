// A simple WPF application, written without XAML.
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllCode
{
    class Program:Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Обработать события Startup и Exit и затем запустить приложение.
            Program app = new Program();
            app.Startup += AppStartUp;
            app.Exit += AppExit;
            app.Run(); // Инициирует событие Startup.
        }

        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited");
        }
        static void AppStartUp(object sender, StartupEventArgs e)
        {
            Application.Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }
            // Создать объект Window и установить некоторые базовые свойства.
            MainWindow wnd = new MainWindow("My better WPF App!", 200, 300);
        }
    }

    class MainWindow : Window
    {
        private Button btnExitApp = new Button();

        public MainWindow(string windowTitle, int height, int width)
        {
            btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
            btnExitApp.Content = "Exit Application";
            btnExitApp.Height = 25;
            btnExitApp.Width = 100;
            this.AddChild(btnExitApp);
            
            // Configure the window.
            this.Title = windowTitle;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Height = height;
            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            this.Width = width;
            this.Show();
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
        }

        void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            btnExitApp.Content = e.Key.ToString();
        }

        void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }
        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)Application.Current.Properties["GodMode"])
                MessageBox.Show("Cheater");
            this.Close();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(msg, "MyApp", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }
    }
    
}
