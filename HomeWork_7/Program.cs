using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите пароль: ");

            string secret = "Пароль";

            if(Console.ReadLine() == secret)
            {
                Console.WriteLine("Доступ разрешен.");
            }

            Console.ReadKey(true);
        }
    }
}
