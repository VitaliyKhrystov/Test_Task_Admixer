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
            bool check = false;

            int[,] array = CreateArray();

            ShowArray(array);

            Console.WriteLine("\n" + new string('-', 50) + "\n");

            do
            {
                array = CheckArrayHorisontal(array);

                ShowArray(array);

                Console.WriteLine("\n" + new string('-', 50) + "\n");

                array = CheckArrayVertical(array);

                ShowArray(array);


                Console.WriteLine("\n" + new string('-', 50) + "\n");


                array = ReplaceMinusOne(array);

                ShowArray(array);


                array = CheckArrayVertical(array);

                ShowArray(array);


                Console.WriteLine("\n" + new string('-', 50) + "\n");


                array = ReplaceMinusOne(array);

                ShowArray(array);

               var result = array.Where

            } while (true);
           

            


           


           

           


          


            


            Console.ReadLine();
        }

        static int[,] CreateArray()
        {
            int[,] array = new int[9, 9];

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 4);
                }
            }

            return array;
        }

        static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "     ");
                }
            }
        }

        static int[,] CheckArrayHorisontal(int[,] array)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] arr = new int[array.GetLength(0)];
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arr[j] = array[i, j];
                }
                arr = ReplaceArrayElement(arr);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = arr[j];
                }
            }

            return array;
        }

        static int[,] CheckArrayVertical(int[,] array)
        {

            for (int j = 0; j < array.GetLength(1); j++)
            {
                int[] arr = new int[array.GetLength(1)];

                int m = 0,
                    n = 0;

                for (int i = array.GetLength(0) - 1; i >= 0 ; i--)
                {
                    if (array[i,j] == -1)
                    {
                        arr[m] = array[i, j];
                        m++;
                    }
                    else
                    {
                        arr[arr.Length - 1 - n] = array[i, j]; ;
                        n++;
                    }
                }

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    array[i, j] = arr[i];
                }
            }

            return array;
        }

        static int[] ReplaceArrayElement(int [] arr)
        {
            var result = arr.GroupBy(g => g).Where(g => g.Count() >= 3);

            foreach (var item in result)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (item.Key == arr[i])
                    {
                        arr[i] = -1;
                    }
                }
            }
            return arr;
        }

        static int[,] ReplaceMinusOne(int[,] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == -1)
                    {
                        array[i, j] = rand.Next(0, 4);
                    }
                   
                }
            }

            return array;

        }
    }
}

//int[] arr = { 1, 2, 3, 1, 4, 8, 1, 2, 2, 3 };

//foreach (var item in arr)
//{
//    Console.Write(item + " ");
//}

//var result = arr.GroupBy(g => g).Where(g => g.Count() >= 3);


//foreach (var item in result)
//{
//    for (int i = 0; i < arr.Length; i++)
//    {
//        if (item.Key == arr[i])
//        {
//            arr[i] = -1;
//        }
//    }
//}

//Console.WriteLine("\n");
//foreach (var item in arr)
//{
//    Console.Write(item + " ");
//}

//Console.WriteLine();

//int[] arr2 = new int[arr.Length];

//int j = 0, k = 0; ;
//for (int i = arr.Length - 1; i >= 0; i--)
//{
//    if (arr[i] == -1)
//    {
//        arr2[j] = arr[i];
//        j++;
//    }
//    else
//    {
//        arr2[arr.Length - 1 - k] = arr[i];
//        k++;
//    }

//}

//foreach (var item in arr2)
//{
//    Console.Write(item + " ");
//}