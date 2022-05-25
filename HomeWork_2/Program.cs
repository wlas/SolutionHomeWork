using System;

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
            Console.WriteLine("4 - Создание чека.");
            Console.WriteLine("5 - Погода.");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Укажите номер:");
        }
        /// <summary>
        /// Выводит в консоль выбронный пункт из меню.
        /// </summary>
        /// <param name="rezult">Номер задания если был выбранн ранне</param>
        static void StartMenu(string rezult = null)
        {
            if (rezult == null)
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
                case "4":
                    Task4_CashCheck();
                    SelectionResult("4");
                    break;
                case "5":
                    Task5();
                    SelectionResult("5");
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
            if (input == "1")
            {
                StartMenu(_case);
            }
            else if (input == "2")
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
        /// Метод узнает и выводит среднесуточную температуру
        /// </summary>
        static void Task1_Temp()
        {
            int temp = averageTemp();
            Console.WriteLine($"Средесуточная температура: {temp}");

        }

        /// <summary>
        /// Метод высчитывает среднесуточную температуру.
        /// </summary>
        /// <returns>Возвращает результат среднесуточной температуры.</returns>
        static int averageTemp()
        {
            int t1 = inputTemp("Укажите значение минимальной температуры за сутки: ");

            int t2 = inputTemp("Укажите значение максимальной температуры за сутки: ");
            int temp = (t1 + t2) / 2;

            return temp;
        }
        /// <summary>
        /// Метод получает введеные данные пользователем
        /// </summary>
        /// <param name="meseg">Сообщенение в котором запрашиваются какие данные требуются ввести пользователем</param>
        /// <returns>Возвращят введенную температуру</returns>
        static int inputTemp(string msg)
        {
            int number = 0;

            try
            {
                Console.Write(msg);
                string temp = Console.ReadLine();
                number = int.Parse(temp);
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка. Данные не определены, пожалуйста повторите.");
                number = inputTemp(msg);
            }

            return number;
        }

        /// <summary>
        /// Метод узнает название месяца по введенному номеру
        /// </summary>
        static void Task2_MonthName()
        {
            try
            {
                int number = inputMonth();
                string nameMonth = findMonth(number);
                Console.WriteLine($"{number} --> {nameMonth}");
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка. Данные не определены, пожалуйста повторите.");
                Task2_MonthName();
            }

        }
        /// <summary>
        /// Метод получает введенный номер месяца пользователя
        /// </summary>
        /// <returns>Возвращает номер месяца</returns>
        static int inputMonth()
        {
            int month = 0;

            Console.Write("\nУкажите номер текущего месяца: ");
            string inputNumber = Console.ReadLine();
            int number = int.Parse(inputNumber);

            if (number > 0 && number < 13)
            {
                month = number;
            }
            else
            {
                Console.Write("\nНеверно. В году 12 месяцев.");
            }

            if (month == 0)
            {
                month = inputMonth();
            }

            return month;
        }

        /// <summary>
        /// Метод определает название месяца
        /// </summary>
        /// <returns>Возвращает название месяца</returns>
        static string findMonth(int number)
        {
            string nameMonth = null;

            DateTime dateTime = new DateTime(2022, number, 1);
            nameMonth = dateTime.ToString("MMMM");

            return nameMonth;
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

                if (number % 2 == 0)
                {
                    if (number <= 0)
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
        /// <summary>
        /// Метод создает чек
        /// </summary>
        static void Task4_CashCheck()
        {
            Console.WriteLine("\nУкажите название компании: ");
            string inputName = Console.ReadLine();

            Console.WriteLine("\nУкажите название товара: ");
            string inputTovar = Console.ReadLine();

            Console.WriteLine($"\nУкажите стоимость товара \"{inputTovar}\": ");
            string inputSum = Console.ReadLine();

            CreateCachChek(inputName, inputTovar, inputSum);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputName"></param>
        /// <param name="inputTovar"></param>
        /// <param name="inputSum"></param>
        static void CreateCachChek(string inputName, string inputTovar, string inputSum)
        {
            try
            {
                double sum = double.Parse(inputSum);
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Наиминование компании: \"{inputName}\"");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Дата продажи: " + DateTime.Now);
                Console.WriteLine($"Название товара и цена: ");
                Console.WriteLine($"{inputTovar} - {sum:F2} руб.");
                Console.WriteLine($"ИТОГО: {sum:F2} руб.");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Спасибо за покупку!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка. Данные не определены, пожалуйста повторите.");
                Task4_CashCheck();
            }
        }
        /// <summary>
        /// Метод узнает дождливая зима или нет
        /// </summary>
        static void Task5()
        {
            int number = inputMonth();
            string nameMonth = findMonth(number);
            int temp = averageTemp();

            Console.WriteLine($"{number} --> {nameMonth}");
            Console.WriteLine($"Средесуточная температура: {temp}");

            if (number == 1 || number == 2 || number == 12)
            {
                if (temp > 0)
                {
                    Console.WriteLine("Дождливая зима.");
                }
                else
                {
                    Console.WriteLine("Зима не дождливая.");
                }
            }
        }
    }
}
