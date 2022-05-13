using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите имя:");
            string userName = Console.ReadLine();

            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"Привет, {userName}, сегодня {dateTime}");
            Console.ReadKey();
        }
    }
}
