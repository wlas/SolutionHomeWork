using System;
using System.Diagnostics;

namespace HomeWork_6
{
    internal class Program
    {
        static Process[] processe;
        static void Main(string[] args)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++ Task Manager +++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            
            StartMenu();
        }


        /// <summary>
        /// Вывод меню в консоль.
        /// </summary>
        static void IntroMenu()
        {
            Console.WriteLine("+++++++++++++++ВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:+++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("1 - Вывести список процессов.");
            Console.WriteLine("2 - Завершить процесс по ID");
            Console.WriteLine("3 - Завершить процесс по его названию.");
            Console.WriteLine("0 - Чтобы выйти из программы.");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
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
                        ListProcess();
                        break;
                    case "2":
                        Menu2();
                        break;
                    case "3":
                        Menu3();
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
        /// Метод выводит на консоль список процессов
        /// </summary>
        static void ListProcess()
        {
            processe = Process.GetProcesses();
            Console.WriteLine("PName                           PID    SessionId           Memory");
            Console.WriteLine("=========================  ========  =========== ================");

            foreach (Process process in processe)
            {
                string procName = string.Empty;

                if (process.ProcessName.Length > 25)
                {
                    procName = process.ProcessName.Substring(0, 25);
                }
                else
                {
                    procName = process.ProcessName;
                }

                string str = String.Format("{0,-25} {1,9} {2,12} {3,13} КБ"
                , procName
                , process.Id
                , process.SessionId
                , process.PrivateMemorySize64);

                Console.WriteLine(str);
            }
        }      


        /// <summary>
        /// Метод получает от пользователя номер процесса для его завершения
        /// </summary>
        static void Menu2()
        {
            Console.Write("Укажите номер процесса: ");

            if(Int32.TryParse(Console.ReadLine().Trim(), out int id))
            {
                KillProcessID(id);
            }
            else
            {
                Console.WriteLine("Ошибка. Процесс не определен.");
            }
        }

        /// <summary>
        /// Метод получает от пользователя номер процесса для его завершения
        /// </summary>
        static void Menu3()
        {
            try
            {
                Console.Write("Укажите название процесса: ");

                string input = Console.ReadLine().Trim();

                if (input != string.Empty)
                {
                    int id = 0;

                    for (int i = 0; i < processe.Length; i++)
                    {
                        if (processe[i].ProcessName == input)
                        {
                            id = processe[i].Id;
                            break;
                        }
                    }

                    if(id != 0)
                    {
                        KillProcessID(id);
                    }
                    else
                    {
                        Console.WriteLine("Процесс не определен.");
                        Console.WriteLine("----------------------------------------------------------------\n");

                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
              
        }

        /// <summary>
        /// Завершение процесса
        /// </summary>
        /// <param name="id">Номер процесса</param>
        static void KillProcessID(int id)
        {
            try
            {
                Process process = Process.GetProcessById(id);
                process.Kill();
                Console.WriteLine("Процесс успешно завершен.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("----------------------------------------------------------------\n");
        }
    }
}
