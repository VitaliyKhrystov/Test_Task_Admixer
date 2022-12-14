using NLog;
using System;
using System.Linq;


namespace Test_Task_Admixer
{
    internal class Program
    {
        //Завдання 1. Аналог три в ряд
        //Матриця 9х9 випадково заповнюється числами від 0 до 3 включно.
        //Якщо по горизонталі/вертикалі збігаються 3 або більше чисел, 
        //видаляємо їх, зсунувши всі елементи матриці зверху донизу 
        //заповнивши порожній простір.Порожні елементи, що залишилися, 
        //заповнюємо випадковими числами від 0 до 3 включно.Повторюємо 
        //процедуру доти не буде збігів. Результат виконання вивести/залогувати


        static void Main(string[] args)
        {
            var Logger = LogManager.GetCurrentClassLogger();

            MyArray myArray = new MyArray();

            string[,] array = myArray.CreateArray();

            myArray.ShowArray(array, "New Array");

            Logger.Info(myArray.GetArrayString(array, "New Array"));

            myArray.GetArrayWithout3orMoreDublicateElements(array);



            Console.ReadLine();
        }

       
    }
}

