// Decompiled with JetBrains decompiler
// Type: HomeWork_7.Program
// Assembly: HomeWork_7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02AAFAFE-F342-4601-8186-0A32DB7FD538
// Assembly location: E:\YandexDisk-a.wlas-off\GB\SolutionHomeWork\HomeWork_7\bin\Debug\HomeWork_7.exe

using System;

namespace HomeWork_7
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.Write("Введите пароль: ");
      string str = "Новый пароль";
      if (Console.ReadLine() == str)
        Console.WriteLine("Доступ разрешен.");
      Console.ReadKey(true);
    }
  }
}
