using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_5
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
            Console.WriteLine("ВЫБЕРЕТЕ НУЖНЫЙ ПУНКТ ИЗ МЕНЮ НИЖЕ:");
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
                        Console.ReadKey(true);
                        return;
                    default:
                        Console.WriteLine("Не определено. Пожалуйста, укажите цифру повторно.");
                        break;
                }
            }
        }
        #region Task 1
        /// <summary>
        /// Задание 5.1
        /// </summary>
        static void Task1()
        {
            Console.Write("Введите произвольные данные для записи в текстовый файл: ");
            string input = Console.ReadLine();
            WriteToFile(input);

        }
        /// <summary>
        /// Метод записывает данные в текстовый файл и выводит на консоль все строки из этого файла
        /// </summary>
        /// <param name="str">Данные для записи в файл</param>
        static void WriteToFile(string str)
        {
            string filePath = "text.txt";

            File.WriteAllText(filePath, str); // записываем в файл строку
            string fileText = File.ReadAllText(filePath); //Считываем все строки из файла
            Console.WriteLine("Читаем строки из текствого файла: " + filePath);
            Console.WriteLine(fileText);

            Console.WriteLine("-----------------------");
        }
        #endregion

        #region Task 2
        /// <summary>
        /// Задание 5.2
        /// </summary>
        static void Task2()
        {
            try
            {
                CreateDir();

                Console.WriteLine("-----------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        /// <summary>
        /// Метод создает файл при его отсутствии, в другом случае задает текущее время обращения к файлу в название файла
        /// </summary>
        static void CreateDir()
        {
            string dir = "WorkFolder";
            string filePath = $"startup_{DateTime.Now.ToString("HH-mm-ss")}.txt";
            string fileDir = Path.Combine(dir, filePath);
            string notePathOld = string.Empty;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                CreateFile(fileDir);
            }
            else
            {
                string[] entries = Directory.GetFileSystemEntries(dir, "*.txt", SearchOption.AllDirectories);

                if(entries.Length == 0)
                {
                    CreateFile(fileDir);
                }
                else
                {
                    for (int i = 0; i < entries.Length; i++)
                    {
                        notePathOld =  entries[i];
                        File.Move(notePathOld, fileDir);
                        break;
                    }

                    Console.WriteLine("Старое название: " + notePathOld + " --> Новое название: " + fileDir);
                }              

            }
        }
        /// <summary>
        /// Метод создает файл
        /// </summary>
        /// <param name="fileDir">Путь файла</param>
        static void CreateFile(string fileDir)
        {
            using (File.Create(fileDir))
            Console.WriteLine("Создан новый файл: " + fileDir);
        }

        #endregion
    }
}
