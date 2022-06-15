using FileManager.Utils;
using System;
using System.IO;
using System.Text;

namespace ConsoleFileManager
{
    internal class Program
    {
        const string fileComands = "SaveCommands.bin";
        static int numb = -1;
        const int WINDOW_HEIGHT = 30;
        const int WINDOW_WIDTH = 120;
        private static string currentDir = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Title = "FileManager";

                Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
                Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);

                DrawWindow(0, 0, WINDOW_WIDTH, 18);
                DrawWindow(0, 18, WINDOW_WIDTH, 8);
                UpdateConsole();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Вспомогательный метод, получить текущую позицию курсора
        /// </summary>
        /// <returns></returns>
        static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        /// <summary>
        /// Обработка процесса ввода данных с консоли
        /// </summary>
        /// <param name="width">Длина строки ввода</param>
        static void ProcessEnterCommand(int width)
        {
            (int left, int top) = GetCursorPosition();

            StringBuilder command = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            char key;

            do
            {
                keyInfo = Console.ReadKey();
                key = keyInfo.KeyChar;

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace &&
                keyInfo.Key != ConsoleKey.UpArrow)
                    command.Append(key);

                (int currentLeft, int currentTop) = GetCursorPosition();

                if (currentLeft == width - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);
                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        command.Clear();
                        Console.SetCursorPosition(left, top);
                    }
                }

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    string str = SelectCommand(left, top, true);

                    command.Clear();
                    command.Append(str);
                    Console.Write(str);

                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    string str = SelectCommand(left, top, false);

                    command.Clear();
                    command.Append(str);
                    Console.Write(str);
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            ParseCommandString(command.ToString());
            numb = -1;
        }
        /// <summary>
        /// Возвращаем массив команд из файла.
        /// </summary>
        /// <returns>Возвращается массив команд из файла</returns>
        static string[] SelectSaveCommands()
        {
            string[] lines = null;

            if (File.Exists(fileComands))
            {
                lines = File.ReadAllLines(fileComands);                
            }
            return lines;
        }
        /// <summary>
        /// Вывод раннее записанной команды на консоль
        /// </summary>
        /// <param name="left">Расположение курсора по оси X</param>
        /// <param name="top">Расположение курсора по оси Y</param>
        /// <param name="rezult">true - стрелка вверх; false - стрелка вниз</param>
        /// <returns></returns>
        static string SelectCommand(int left, int top, bool rezult)
        {
            (int currentLeft, int currentTop) = GetCursorPosition();
            string str = null;

            string[] arr = SelectSaveCommands();

            if (arr != null)
            {
                if (arr.Length > 0)
                {
                    if (rezult == true)
                    {
                        if (numb == -1)
                        {
                            numb = arr.Length - 1;
                            str = arr[numb];
                        }
                        else
                        {
                            if (numb <= arr.Length && numb > 0)
                            {
                                if (numb == arr.Length)
                                {
                                    numb = arr.Length - 1;
                                }
                                str = arr[numb--];
                            }
                            else
                            {
                                str = arr[0];
                            }
                        }
                    }
                    else
                    {
                        if (numb == -1)
                        {
                            str = arr[0];
                            numb = 0;
                        }
                        else
                        {
                            if (numb < arr.Length && numb >= 0)
                            {
                                str = arr[numb++];
                            }
                        }
                    }
                }
                do
                {
                    Console.SetCursorPosition(--currentLeft, top);
                    Console.Write(" ");
                }
                while (currentLeft != left);
            }

            return str;            
        }

        /// <summary>
        /// Выводит на консоль информацию о файле
        /// </summary>
        /// <param name="file">Ссылка на файл</param>
        static void FInfo(FileInfo file)
        {
            Console.SetCursorPosition(2, 19);
            Console.WriteLine(file.Attributes);
            Console.SetCursorPosition(2, 20);
            Console.WriteLine(file.CreationTime);
            Console.SetCursorPosition(2, 21);
            Console.WriteLine(file.LastAccessTime);
            Console.SetCursorPosition(2, 22);
            Console.WriteLine(file.Extension);
            Console.SetCursorPosition(2, 23);
            Console.WriteLine(file.Length + " bytes actual size");
        }
        /// <summary>
        /// Вывод на консоль информации о папке
        /// </summary>
        /// <param name="dir">Путь к папке</param>
        static void DInfo(DirectoryInfo dir)
        {
            Console.SetCursorPosition(2, 19);
            Console.WriteLine(dir.Attributes);
            Console.SetCursorPosition(2, 20);
            Console.WriteLine(dir.CreationTime);
            Console.SetCursorPosition(2, 21);
            Console.WriteLine(dir.LastAccessTime);
            Console.SetCursorPosition(2, 22);
            Console.WriteLine("Exists: " + dir.Exists);
            Console.SetCursorPosition(2, 23);
            Console.WriteLine(dir.FullName);
        }
        /// <summary>
        /// Метод выполняет команды введенные пользователем
        /// </summary>
        /// <param name="command">Команда переданная пользователем</param>
        static void ParseCommandString(string command)
        {            
            string[] commandParams = command.ToLower().Split(' ');

            if (commandParams.Length > 0)
            {
                if(command.Length > 1)
                {
                    if (!File.Exists(fileComands))
                    {
                        File.WriteAllText(fileComands, command.Trim() + "\n");
                    }
                    else
                    {
                        if (!SearchCommands(command.Trim()))
                        {
                            File.AppendAllText(fileComands, command.Trim() + "\n");
                        }                        
                    }
                }               

                switch (commandParams[0])
                {
                    case "cd":
                        if (commandParams.Length > 1)
                            if (Directory.Exists(commandParams[1]))
                            {
                                currentDir = commandParams[1];
                                Properties.Settings.Default.Path = currentDir;
                                Properties.Settings.Default.Save();
                            }
                        break;
                    case "ls":
                        if (commandParams.Length > 1)
                        {
                            if (commandParams.Length > 2 && commandParams[1] == "-p" && int.TryParse(commandParams[2], out int n))
                            {
                                DrawTree(new DirectoryInfo(currentDir), n, false);
                            }
                            else if (commandParams[1] == "-s")
                            {
                                DrawTree(new DirectoryInfo(currentDir), 1, true);
                            }
                            else if (commandParams[1] == "-sp" && int.TryParse(commandParams[2], out int s))
                            {
                                DrawTree(new DirectoryInfo(currentDir), s, true);
                            }
                        }
                        else
                        {
                            DrawTree(new DirectoryInfo(currentDir), 1, false);
                        }
                        break;
                    case "cp":
                        if (commandParams.Length > 2)
                        {
                            if (File.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                if (Directory.Exists(commandParams[2]))
                                {


                                    File.Create(commandParams[2] + @"\" + commandParams[1]).Dispose();
                                    File.Copy(currentDir + @"\" + commandParams[1], (commandParams[2] + @"\" + commandParams[1]), true);


                                }
                                else if (!Directory.Exists(currentDir + @"\" + commandParams[2]))
                                {
                                    Directory.CreateDirectory(commandParams[2]);
                                    File.Create(commandParams[2] + @"\" + commandParams[1]).Dispose();
                                    File.Copy(commandParams[1], (commandParams[2] + @"\" + commandParams[1]), true);

                                }
                            }
                            else if (Directory.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                if (!Directory.Exists(commandParams[2]))
                                {
                                    Directory.CreateDirectory(commandParams[2]);
                                    CopyDirectory(currentDir + @"\" + commandParams[1], commandParams[2], true);

                                }
                                else
                                {
                                    CopyDirectory(currentDir + @"\" + commandParams[1], commandParams[2], true);
                                }
                            }
                        }
                        break;
                    case "info":
                        if (commandParams.Length > 1)
                        {
                            if (File.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                System.Threading.Thread.Sleep(100);
                                FInfo(new FileInfo(currentDir + @"\" + commandParams[1]));
                            }
                            else if (Directory.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                System.Threading.Thread.Sleep(100);
                                DInfo(new DirectoryInfo(currentDir + @"\" + commandParams[1]));
                            }
                        }
                        break;
                    case "rm":
                        if (commandParams.Length > 1)
                        {
                            if (File.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                File.Delete(currentDir + @"\" + commandParams[1]);
                            }
                            else if (Directory.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                DelDirectory(currentDir + @"\" + commandParams[1]);
                            }
                        }
                        break;
                    case "mv":
                        if (commandParams.Length > 2)
                        {
                            if (File.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                if (Directory.Exists(commandParams[2]))
                                {
                                    File.Create(commandParams[2] + @"\" + commandParams[1]).Dispose();
                                    File.Copy(currentDir + @"\" + commandParams[1], (commandParams[2] + @"\" + commandParams[1]), true);
                                    File.Delete(currentDir + @"\" + commandParams[1]);
                                }
                                else if (!Directory.Exists(currentDir + @"\" + commandParams[2]))
                                {
                                    Directory.CreateDirectory(commandParams[2]);
                                    File.Create(commandParams[2] + @"\" + commandParams[1]).Dispose();
                                    File.Copy(commandParams[1], (commandParams[2] + @"\" + commandParams[1]), true);
                                    File.Delete(commandParams[1]);
                                }
                            }
                            else if (Directory.Exists(currentDir + @"\" + commandParams[1]))
                            {
                                if (!Directory.Exists(commandParams[2]))
                                {
                                    Directory.CreateDirectory(commandParams[2]);
                                    CopyDirectory(currentDir + @"\" + commandParams[1], commandParams[2], true);
                                    DelDirectory(currentDir + @"\" + commandParams[1]);
                                }
                                else
                                {
                                    CopyDirectory(currentDir + @"\" + commandParams[1], commandParams[2], true);
                                    DelDirectory(currentDir + @"\" + commandParams[1]);
                                }
                            }
                        }
                        break;
                    case "mkdir":
                        if (commandParams.Length > 1)
                        {
                            if (!Directory.Exists(commandParams[1]))
                            {
                                Directory.CreateDirectory(currentDir + @"\" + commandParams[1]);
                            }
                        }
                        break;
                    case "touch":
                        if (commandParams.Length != 0)
                        {
                            if (!File.Exists(commandParams[1]))
                            {
                                File.Create(currentDir + @"\" + commandParams[1]).Dispose();
                            }
                        }
                        break;
                    case "save":
                        Properties.Settings.Default.Save();
                        break;
                    case "load":
                        currentDir = Properties.Settings.Default.Path;
                        break;
                    case "exit":
                        Properties.Settings.Default.Save();
                        System.Environment.Exit(0);
                        break;
                    case "page-items":
                        if (commandParams.Length > 1)
                        {
                            if (uint.TryParse(commandParams[1], out uint pageElements))
                            {
                                Properties.Settings.Default.Element = pageElements;
                                Properties.Settings.Default.Save();
                            }
                        }
                        break;

                }
            }
            UpdateConsole();
        }
        /// <summary>
        /// Поиск введенной команды в сохранненом списке ранее
        /// </summary>
        /// <param name="command">Команда введенная пользователем</param>
        /// <returns>true - нашлась команда; false - не нашлась команда</returns>
        static bool SearchCommands(string command)
        {
            bool rezult = false;

            if (File.Exists(fileComands))
            {
                string[] commands = SelectSaveCommands();
                for (int i = 0; i < commands.Length; i++)
                {
                    if (commands[i] == command)
                    {
                        rezult = true;
                        break;
                    }
                }
            }

            return rezult;
        }

        /// <summary>
        /// Копирование каталога и подкаталогов
        /// </summary>
        /// <param name="sourceDir">Дерикотрия копирования</param>
        /// <param name="destinationDir">Новая директория</param>
        /// <param name="recursive"></param>
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        /// <summary>
        /// Удаление каталога
        /// </summary>
        /// <param name="sourceDir">Путь на котолог</param>
        static void DelDirectory(string sourceDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(sourceDir, file.Name);
                file.Delete();
            }

            foreach (DirectoryInfo subDir in dirs)
            {
                DelDirectory(subDir.FullName);
            }

            Directory.Delete(sourceDir, true);

        }

        static string GetShortPath(string path)
        {
            StringBuilder shortPathName = new StringBuilder((int)API.MAX_PATH);
            API.GetShortPathName(path, shortPathName, API.MAX_PATH);
            return shortPathName.ToString();
        }

        /// <summary>
        /// Обновление ввода с консоли
        /// </summary>
        static void UpdateConsole()
        {
            DrawConsole(GetShortPath(currentDir), 0, 26, WINDOW_WIDTH, 3);
            ProcessEnterCommand(WINDOW_WIDTH);
        }

        /// <summary>
        /// Отрисовка консоли
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
        }

        /// <summary>
        /// Отрисовка окна
        /// </summary>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawWindow(int x, int y, int width, int height)
        {
            // header - шапка
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╗");

            // window - окно
            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");

                for (int j = x + 1; j < x + width - 1; j++)
                    Console.Write(" ");

                Console.Write("║");
            }

            // footer - подвал
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╝");
            Console.SetCursorPosition(x, y);

        }

        /// <summary>
        /// Отрисовать дерево каталогов
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="page">Страница</param>
        /// <param name="useSettingsFile"></param>
        static void DrawTree(DirectoryInfo dir, int page, bool useSettingsFile)
        {
            StringBuilder tree = new StringBuilder();
            if (useSettingsFile)
            {
                GetTree(tree, dir, "", true, true);
            }
            else
            {
                GetTree(tree, dir, "", true, false);
            }
            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int currentLeft, int currentTop) = GetCursorPosition();
            int pageLines = 16;
            string[] lines = tree.ToString().Split('\n');
            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            if (page > pageTotal)
                page = pageTotal;

            for (int i = (page - 1) * pageLines, counter = 0; i < page * pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);
                    Console.WriteLine(lines[i]);
                }
            }

            // Отрисуем footer
            string footer = $"╡ {page} of {pageTotal} ╞";
            Console.SetCursorPosition(WINDOW_WIDTH / 2 - footer.Length / 2, 17);
            Console.WriteLine(footer);

        }

        static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory, bool useSettingsFile)
        {
            try
            {
                tree.Append(indent);
                if (lastDirectory)
                {
                    tree.Append("└─");
                    indent += "  ";
                }
                else
                {
                    tree.Append("├─");
                    indent += "│ ";
                }

                tree.Append($"{dir.Name}\n");


                FileInfo[] subFiles = dir.GetFiles();
                if (useSettingsFile)
                    Array.Resize(ref subFiles, (int)Properties.Settings.Default.Element);
                if (!useSettingsFile)
                {
                    for (int i = 0; i < subFiles.Length; i++)
                    {
                        if (i == subFiles.Length - 1)
                        {
                            tree.Append($"{indent}└─{subFiles[i].Name}\n");
                        }
                        else
                        {
                            tree.Append($"{indent}├─{subFiles[i].Name}\n");
                        }
                    }
                }
                else
                {
                    int i = 0;

                    do
                    {
                        if (i == subFiles.Length - 1)
                        {
                            if (subFiles[i] != null)
                                tree.Append($"{indent}└─{subFiles[i].Name}\n");
                        }
                        else
                        {
                            if (subFiles[i] != null)
                                tree.Append($"{indent}├─{subFiles[i].Name}\n");

                        }
                        i++;
                    } while (subFiles != null && i < subFiles.Length);
                }

                DirectoryInfo[] subDirects = dir.GetDirectories();

                for (int i = 0; i < subDirects.Length; i++)
                {
                    try
                    {
                        GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1, useSettingsFile);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1, useSettingsFile);
                    }
                    catch (Exception)
                    {
                        Console.Write("XX");
                    }
                }
            }
            catch { }
        }
    }
}
