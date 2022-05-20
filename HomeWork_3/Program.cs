using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        /// <summary>
        /// Вывод меню в консоль.
        /// </summary>
        static void IntroMenu()
        {
            Console.WriteLine("\nВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");            
            Console.WriteLine("1 - Двухмерный массив по диагонали.");
            Console.WriteLine("2 - Телефонный справочник.");
            Console.WriteLine("3 - Строка в обратном порядке.");
            Console.WriteLine("0 - Чтобы выйти из программы.");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.Write("Укажите номер: ");
        }
        /// <summary>
        /// Вывод меню в консоль.
        /// </summary>
        static void StartMenu()
        {
            while (true)
            {
                IntroMenu();
                string rezult = Console.ReadLine();

                switch (rezult)
                {
                    case "1":
                        Task1();                   
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Console.WriteLine("Выбрано 3");
                        break;
                    case "0":
                        Console.WriteLine("Завершение программы.");
                        Console.ReadKey();
                        return;                        
                    default:
                        Console.WriteLine("Не определено. Пожалуйста, укажите цифру повторно.");
                        break;
                }
            }            
        }
        /// <summary>
        /// Задание 3.1
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Двухмерный массив по диагонали");
            Console.WriteLine("==============================");

            int x = 5;
            int y = 5;

            int[,] arr = CreateArray(x,y,10);

            int p = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    p++;
                    for (int f = 0; f < p; f++)
                    {
                        Console.Write(" ");
                        if(f == p - 1)
                        {
                            Console.Write(arr[i, j] + "\n");
                        }
                    }
                }                
            }

            Console.WriteLine("==============================");

        }
        /// <summary>
        /// Метод создает и возвращает двухмерный массив
        /// </summary>        
        /// <param name="x">Первое число измерений</param>
        /// <param name="y">Второе число измерений</param>
        /// <param name="z">Конечное число диапазаона чисел от 1 до</param>
        /// <returns>Двухмерный массив</returns>
        static int[,] CreateArray(int x, int y, int z)
        {
            int[,] arr = new int[x,y];

            Random rand = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = rand.Next(1,z);
                }
            }

            return arr;
        }
        /// <summary>
        /// Задание 3.2
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("\n=====================");
            Console.WriteLine("Телефонный справочник");
            Console.WriteLine("=====================");

            string[,] arrTell = new string[5,2];

            Random random = new Random();

            int numb = 0;

            for (int i = 0; i < arrTell.GetLength(0); i++)
            {
                numb++;

                for (int j = 0; j < arrTell.GetLength(1); j++)
                {
                    if(j == 0)
                    {
                        arrTell[i, j] = "Имя: Человек " + numb;
                    }
                    if(j == 1)
                    {
                        arrTell[i, j] = "+7(" + random.Next(903, 999) + ")" + random.Next(100, 999) +"-" + random.Next(1000, 9999);
                    }
                }
            }

            SelectArray(arrTell);

            Console.WriteLine("=====================");
        }
        /// <summary>
        /// Метод выводит полученный массив в консоль
        /// </summary>
        /// <param name="array">Массив для вывода в консоль</param>
        static void SelectArray(Array array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);

            }
        }
    }
}
