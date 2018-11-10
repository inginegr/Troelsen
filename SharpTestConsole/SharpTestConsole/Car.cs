using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    public class Car
    {
        // Данные состояния.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        // Исправен ли автомобиль? 
        private bool carIsDead;

        // Конструкторы класса.
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        
        // 1. Определить тип делегата.
        public delegate void CarEngineHandler(int x, int y);
        // 2. Определить переменную-член типа этого делегата.
        public CarEngineHandler listOfHandlers;
        // 3. Добавить регистрационную функцию для выбывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        public void clev(int x,int y)
        {
            listOfHandlers(x, y);
        }
        //public void mdm()
        //{
        //    ev1("Param");
        //}
        //public void Accelerate(int delta)
        //{
        //    // Если этот автомобиль сломан, отправить сообщение об этом. 
        //    if (carIsDead)
        //    {
        //        if (listOfHandlers != null)
        //            listOfHandlers("Sorry, this car is dead...");
        //    }
        //    else
        //    {
        //        CurrentSpeed += delta;
        //        // Автомобиль почти сломан?
        //        if (10 == (MaxSpeed - CurrentSpeed)
        //        && listOfHandlers != null)
        //        {
        //            listOfHandlers("Careful buddy! Gonna blow!");
        //        }
        //        if (CurrentSpeed >= MaxSpeed)
        //            carIsDead = true;
        //        else
        //            Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
        //    }
        //}
    }
}
