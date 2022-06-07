using System;
using HomeWork_8.Properties;

namespace HomeWork_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Settings.Default.StartMsg);

            //Добавил проверку, если данные есть выведи на консоль данные
            if(!String.IsNullOrEmpty(Settings.Default.UserName)  && Settings.Default.Age != 0 && !String.IsNullOrEmpty(Settings.Default.Occupation))
            {
                SelectSettigs();
            }


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
                        SelectSettigs();
                        break;
                    case "2":
                        EditSttings();
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
        /// <summary>
        /// Выводит на консоль сохраненные данные
        /// </summary>
        static void SelectSettigs()
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"Имя: {(Settings.Default.UserName == string.Empty ? "-" : Settings.Default.UserName)}");
            Console.WriteLine("Возраст: " + Settings.Default.Age);
            Console.WriteLine($"Род деятельности: {(Settings.Default.Occupation == string.Empty ? "-" : Settings.Default.Occupation)}");
            Console.WriteLine("----------------------------------");

        }

        /// <summary>
        /// Измененяет данные в application Settings
        /// </summary>
        static void EditSttings()
        {
            try
            {
                Console.Write("Укажите имя: ");
                string userName = Console.ReadLine();

                Console.Write("Укажите возраст: ");
                string strAge = Console.ReadLine();

                if(!int.TryParse(strAge, out int age))
                {
                    Console.WriteLine("Ошибка ввода возраста.");
                    return;
                }

                Console.Write("Укажите род деятельности: ");
                string occupation = Console.ReadLine();

                Settings.Default.UserName = userName;
                Settings.Default.Age = age;
                Settings.Default.Occupation = occupation;
                Settings.Default.Save();

                SelectSettigs();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


        }
    }
}
