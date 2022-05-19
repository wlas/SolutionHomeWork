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
            Console.WriteLine("Укажите номер:");
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
                        Console.WriteLine("Выбрано 1");                        
                        break;
                    case "2":
                        Console.WriteLine("Выбрано 2");
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
    }
}
