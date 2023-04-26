using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tmp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tm t=new Tm();
            for(int i=0;i<20;i++){
                Task tsk = Task.Run(()=>{
                    t.Met();
                });
            }

            Console.WriteLine("Hello");
            Console.ReadLine();
        }
    }

    class Tm{
        object locker=new Object();
        int ob=0;
        public void Met(){
            lock(locker){
                Console.WriteLine($"Before sleep {ob}");
                Thread.Sleep(500);
                Console.WriteLine($"After sleep {ob}");
                ob++;
            }
        }
    }

}
