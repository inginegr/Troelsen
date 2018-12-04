using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

// Be sure to import these namespaces:
using MathServiceLibrary;
using System.ServiceModel;


namespace MathWindowsServiceHost
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost myHost;
        public MathWinService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (myHost != null)
            {
                myHost.Close();
                myHost = null;
            }
            myHost = new ServiceHost(typeof(MathService));

            Uri address = new Uri("http://localhost:8080/MathServiceLibrary");
            WSHttpBinding binding = new WSHttpBinding();
            Type contract = typeof(IBasicMath);

            myHost.AddServiceEndpoint(contract, binding, address);

            myHost.Open();
        }
        protected override void OnStop()
        {
            if (myHost != null)
                myHost.Close();
        }
    }
}
