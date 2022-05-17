using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
            Console.ReadKey();
        }
        /// <summary>
        /// Вывод меню в консоль.
        /// </summary>
        static void IntroMenu()
        {
            Console.WriteLine("ВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("0 - Чтобы выйти из программы.");
            Console.WriteLine("1 - Узнать среднесуточную температуру за сутки.");
            Console.WriteLine("2 - Узнать название месяца по введенному номеру.");
            Console.WriteLine("3 - Узнать является ли число чётным.");            
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Укажите цифру:");
        }
        /// <summary>
        /// Выводит в консоль выбронный пункт из меню.
        /// </summary>
        /// <param name="rezult">Номер задания если был выбранн ранне</param>
        static void StartMenu(string rezult = null)
        {
            if(rezult == null)
            {
                IntroMenu();
                rezult = Console.ReadLine();
            }   

            switch (rezult)
            {
                case "1":
                    Task1Temp();
                    SelectionResult("1");
                    break;
                case "2":
                    Console.WriteLine("Выбрано 2");
                    SelectionResult("2");
                    break;
                case "3":
                    Console.WriteLine("Выбрано 3");
                    SelectionResult("3");
                    break;
                case "0":
                    Environment.Exit(0);  //Подсмотрел в Googlе =)
                    break;
                default:
                    Console.WriteLine("\nНе определено. Пожалуйста, укажите цифру повторно.\n");
                    StartMenu();
                    break;
            }            
        }
        /// <summary>
        /// Метод запрашивает у пользователя повторное выполнение текущего задания по его окончанию.
        /// </summary>
        /// <param name="_case">Номер текущего задания</param>
        static void SelectionResult(string _case)
        {
            Console.WriteLine("\nПовторить? Введите да или нет.\n");
            string input = Console.ReadLine();
            if(input == "да")
            {
                StartMenu(_case);
            }
            else if(input == "нет")
            {
                Console.WriteLine("\n-----------------------------------------------\n");
                StartMenu();
            }
            else
            {
                Console.WriteLine("Не определено. Пожалуйста повторите.");
                SelectionResult(_case);
            }
            

        }
        /// <summary>
        /// Метод узнает среднесуточную температуру
        /// </summary>
        static void Task1Temp()
        {
            Console.Write("\nУкажите значение минимальной температуры за сутки: ");
            string temp1 = Console.ReadLine();
            int t1 = int.Parse(temp1);

            Console.Write("Укажите значение максимальной температуры за сутки: ");
            string temp2 = Console.ReadLine();
            int t2 = int.Parse(temp2);
            
            int t3 = (t1 + t2) / 2;
            Console.WriteLine($"Средесуточная температура: {t3}");
        }

    }
}
