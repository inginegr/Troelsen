using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    public class MyResourceWrapper : IDisposable
    {
        // После окончания работы с объектом пользователь 
        // объекта должен вызывать этот метод. 
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы...
            // Освободить другие содержащиеся внутри освобождаемые объекты.
            // Только для целей тестирования.
            Console.WriteLine("***** in Dispose! *****");
        }
    }
}
