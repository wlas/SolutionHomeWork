using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4
{
    internal class Program
    {
        static string[] users = new string[] { "Иванов Иван Иваныч", "Васильев Василий Васильевич" };
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
            Console.WriteLine("1 - Задание 1");
            Console.WriteLine("2 - Задание 2");
            Console.WriteLine("3 - Задание 3");
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
        #region Task1
        /// <summary>
        /// Задание 4.1
        /// </summary>
        static void Task1()
        {
            StartMenuUsers();
        }

        static void StartMenuUsers()
        {
            while (true)
            {
                MenuUser();
                string rezult = Console.ReadLine();                

                switch (rezult)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        SelectUser(users);
                        break;                    
                    case "0":
                        Console.WriteLine("Выход.");
                        return;
                    default:
                        Console.WriteLine("Не определено. Пожалуйста, укажите цифру повторно.");
                        break;
                }
            }
        }
        /// <summary>
        /// Метод для сбора введенных данных
        /// </summary>
        private static void AddUser()
        {
            Console.Write("Укажите Фамилию: ");
            string firstName = Console.ReadLine();
            Console.Write("Укажите Имя: ");
            string lastName = Console.ReadLine();
            Console.Write("Укажите Отчество: ");
            string patronymic = Console.ReadLine();

            GetFullName(firstName, lastName, patronymic);
        }
        /// <summary>
        /// Меню для работы со справочником
        /// </summary>
        private static void MenuUser()
        {
            Console.WriteLine("\nВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.WriteLine("1 - Добавить человека в список.");
            Console.WriteLine("2 - Вывести весь список.");
            Console.WriteLine("0 - Выход.");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.Write("Укажите номер: ");
        }
        /// <summary>
        /// Добавление ФИО в массив и вывод на консоль
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        static void GetFullName(string firstName, string lastName, string patronymic)
        {
            string fio = $"{firstName} {lastName} {patronymic}";
            int index = users.Length + 1;
            Array.Resize(ref users, index);

            users[index - 1] = fio;

            Console.WriteLine($"{fio} - успешно добавлен.");
        }
        /// <summary>
        /// Метод выводит массив на консоль
        /// </summary>
        /// <param name="arr">Массив</param>
        static void SelectUser(params string[] arr)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("-------------ФИО-------------");
            Console.WriteLine("-----------------------------");

            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------");
        }
        #endregion

        #region Task2
        /// <summary>
        /// Задание 4.2
        /// </summary>
        private static void Task2()
        {
            try
            {
                Console.Write("Введите любые числа через пробел: ");
                string input = Console.ReadLine();
                string[] number = input.Split(' ');

                int rezult = 0;

                foreach (string item in number)
                {
                    rezult += Convert.ToInt32(item);
                }

                Console.WriteLine("Сумма всех чисел равна: " + rezult);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка. Значения не определены!");
            }
            
        }
        #endregion
    }
}
