using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Properties.Settings.Default.StartMsg);

            StartMenu();
        }

        /// <summary>
        /// Вывод меню в консоль.
        /// </summary>
        static void IntroMenu()
        {
            Console.WriteLine("\nВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("1 - Вывести сохраненные данные.");
            Console.WriteLine("2 - Перезаписать новые данные.");
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
                        
                        break;
                    case "2":
                        ;
                        break;
                    case "3":
                        
                        break;
                    case "0":
                        Console.WriteLine("Завершение программы.");
                        Console.ReadKey(true);
                        return;
                    default:
                        Console.WriteLine("Не определено. Пожалуйста, укажите цифру повторно.");
                        break;
                }
            }
        }
    }
}
