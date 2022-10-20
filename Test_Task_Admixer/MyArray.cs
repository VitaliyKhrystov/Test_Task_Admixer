using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Admixer
{
    public class MyArray
    {
        public string[,] CreateArray()
        {
            string[,] array = new string[9, 9];

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 4).ToString();
                }
            }

            return array;
        }

        public void ShowArray(string[,] array, string title)
        {
            Console.WriteLine("\n" + new string('-', 20) + $" {title} " + new string('-', 20) + "\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "   ");
                }
            }

            Console.WriteLine("\n");
        }

        public void GetArrayWithout3orMoreDublicateElements(string[,] array)
        {
            bool check = false;
            do
            {
                array = FindMatches(array);

                ShowArray(array, "Find Matches");

                check = IsContain(array, " ");

                if (check)
                {
                    array = MoveElemetArray(array);
                    ShowArray(array, "Move Element");

                    array = FillEmptyElement(array);
                    ShowArray(array, "Fill Empty Element");
                }

            } while (check);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            ShowArray(array, "Result");
            Console.ResetColor();
        }

        public string[,] FindMatches(string[,] array)
        {
            string[,] array2 = new string[array.GetLength(0), array.GetLength(1)];

            string[,] array3 = new string[array.GetLength(0), array.GetLength(1)];

            // Пробігаємось по горизонталі
            for (int i = 0; i < array.GetLength(0); i++)
            {
                string[] arr = new string[array.GetLength(0)];
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arr[j] = array[i, j];
                }
                arr = ReplaceArrayElement(arr);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array2[i, j] = arr[j];
                }
            }

            // Пробігаємось по вертикалі
            for (int i = 0; i < array.GetLength(1); i++)
            {
                string[] arr = new string[array.GetLength(0)];
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    arr[j] = array[j, i];
                }
                arr = ReplaceArrayElement(arr);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array3[j, i] = arr[j];
                }
            }

            // Вносимо результат в результуючий масив
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    if (array2[i, j] == array3[i, j])
                    {
                        array[i, j] = array2[i, j];
                    }
                    else if (array2[i, j] == " " || array3[i, j] == " ")
                    {
                        array[i, j] = " ";
                    }

                }
            }

            return array;
        }

        public string[] ReplaceArrayElement(string[] arr)
        {
            int count = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        ++count;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count >= 3)
                {
                    for (int k = i; k < i + count; k++)
                    {
                        arr[k] = " ";
                    }
                    i = i + count - 1;
                }
                count = 1;
            }

            return arr;
        }

        public string[,] MoveElemetArray(string[,] array)
        {

            for (int j = 0; j < array.GetLength(1); j++)
            {
                string[] arr = new string[array.GetLength(1)];

                int m = 0,
                    n = 0;

                for (int i = array.GetLength(0) - 1; i >= 0; i--)
                {
                    if (array[i, j] == " ")
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

        public string[,] FillEmptyElement(string[,] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == " ")
                    {
                        array[i, j] = rand.Next(0, 4).ToString();
                    }

                }
            }

            return array;
        }

        public bool IsContain(string[,] array, string value)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
