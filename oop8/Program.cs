using System;
using System.Collections.Generic;
using System.IO;

namespace oop8
{

   public class Program
    {
        
       //Реализация отображения размерности файлов
        static string SizeFormat(long size)
        {

            string[] endings = { "b", "kb", "mb", "gb" };
            string end = endings[0];
            for (int i = 0; i < 4; i++)
            {
                end = endings[i];
                if (size >= 1024)
                {
                    size /= 1024;
                }
                else
                    break;

            }
            return $"{size} {end}";
        }
        //Реализация метода вывода на экран строк элементов списка класса "Свойства элементов"
        static void PrintItem(MainProperties item)
        { // отображение имени элемента
            var name = item.Name.Length <= 50 ? item.Name : $"{item.Name.Substring(0, 47)}...";
            //отображение типа элементов (файлы/директории
            var itemType = item.Size.HasValue ? string.Empty : "Dir";
            //отображение размерности файлов
            var size = item.Size.HasValue ? SizeFormat(item.Size.Value) : string.Empty;
            //Вывод на экран консоли
            Console.WriteLine($"{name,-50} {itemType,3 } {size,15}");
        }
        //Отображение файлового менеджера
        static void InfoList(IEnumerable<MainProperties> items, MainProperties selected = null)
        {
            Console.ResetColor();
            Console.Clear();
            //реализация выделения элементов
            foreach (var item in items)
            {
                if (item.Equals(selected))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //Вывод на экран строк элементов списка класса "Свойства элементов"
                PrintItem(item);
            }
           
        }
       public static void Main (string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;
            //Создание переменной с присвоением класса 
            var FileManager = new Operation();
            //Отображение файлового менеджера
            InfoList(FileManager.Items, FileManager.Selected);
            while (true)
            {//Назначение клавиш
                var inputKey = Console.ReadKey(false);
                switch (inputKey.Key)
                {
                    
                    case ConsoleKey.PageUp:
                        FileManager.First();
                        break;
                    case ConsoleKey.PageDown:
                        FileManager.Last();
                        break;
                    case ConsoleKey.UpArrow:
                        FileManager.Previous();
                        break;
                    case ConsoleKey.DownArrow:
                        FileManager.Next();
                        break;
                    case ConsoleKey.Enter:
                        FileManager.Open();
                        break;
                    case ConsoleKey.C:
                        FileManager.СopyFile();
                        break;
                    case ConsoleKey.Delete:
                        if (DeleteWindow(FileManager.Selected))
                            FileManager.Delete();
                        break;
                    case ConsoleKey.M:
                        FileManager.MoveDir();
                        break;
                    case ConsoleKey.A:
                        FileManager.CreateDir();
                        break;
                    case ConsoleKey.Home:
                        FileManager.Home();
                        break;
                    case ConsoleKey.H:
                        FileManager.HelpMenu();
                        break;
                    case ConsoleKey.D:
                        FileManager.HDDInfo();
                        break;
                    case ConsoleKey.Q:
                        FileManager.Quit();
                        break;
                }
                InfoList(FileManager.Items, FileManager.Selected);
                //Вывод на экран информации о списке комманд
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Для вызова меню комманд мнажмите H");
            }
        }
        //Информационное окно метода удаления
        static bool DeleteWindow(MainProperties item)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine(item.MainPath);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Удалить выбранный элемент? Для подтверждения нажмите клавишу Y.");
            Console.ResetColor();
            var key = Console.ReadKey();
            return key.Key == ConsoleKey.Y;
        }
        
        
    }
    
}

