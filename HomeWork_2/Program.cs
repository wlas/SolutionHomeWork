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
            Console.WriteLine("Укажите номер:");
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
                    Task1_Temp();
                    SelectionResult("1");
                    break;
                case "2":
                    Task2_MonthName();
                    SelectionResult("2");
                    break;
                case "3":
                    Task3_EvenNumber();
                    SelectionResult("3");
                    break;
                case "0":
                    return;

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
            Console.WriteLine("\nПовторить? Введите 1 - ДА или 2 - НЕТ.\n");
            string input = Console.ReadLine();
            if(input == "1")
            {
                StartMenu(_case);
            }
            else if(input == "2")
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
        static void Task1_Temp()
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
        /// <summary>
        /// Метод узнает название месяца по введенному номеру
        /// </summary>
        static void Task2_MonthName()
        {
            try
            {
                Console.Write("\nУкажите номер текущего месяца: ");
                string rezult = Console.ReadLine();
                int number = int.Parse(rezult);

                if (number > 0 && number < 13)
                {
                    DateTime dateTime = new DateTime(2022, number, 1);
                    Console.WriteLine($"{number} --> {dateTime.ToString("MMMM")}");
                }
                else
                {
                    Console.Write("\nНеверно. В году 12 месяцев.");
                    Task2_MonthName();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка. Данные не определены, пожалуйста повторите.");
                Task2_MonthName();
            }            
            
        }
        /// <summary>
        /// Метод получает число от пользователя.
        /// </summary>
        static void Task3_EvenNumber()
        {            
            Console.Write("\nУкажите число для проверки: ");
            string input = Console.ReadLine();
            CheckEvenNumber(input);
        }
        /// <summary>
        /// Метод определет и выводит в консоль число четное или нечетное.
        /// </summary>
        /// <param name="strNumb">Получает введенное число пользователем.</param>
        static void CheckEvenNumber(string strNumb)
        {
            try
            {
                int number = int.Parse(strNumb);
                
                if(number % 2 == 0)
                {
                    if(number <= 0)
                    {
                        Task3_EvenNumber();
                    }
                    else
                    {
                        Console.WriteLine("Число четное.");
                    }
                }
                else
                {
                    Console.WriteLine("Число нечетное.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка. Данные не определены, пожалуйста повторите.");
                Task3_EvenNumber();
            }
        }
    }
}
