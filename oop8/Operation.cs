using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace oop8
{

    public class Operation
    {   //создание объектов типа "Свойства элементов"
        //Выбор элемента
        public MainProperties Selected { get; private set; }
        //Список объектов выбранной директории
        public List<MainProperties> Items { get; private set; }
        //создание менеджера с начальной директорией текущего диска (конструктор по умолчанию, который вызывает другой конструктор этого же класса, затем выполняется сам)
        public Operation()

            : this(Path.GetPathRoot(Directory.GetCurrentDirectory())) { }

        public Operation(string initPath)
        {
            if (!ChangePath(initPath))
                ChangePath(Path.GetPathRoot(Directory.GetCurrentDirectory()));
        }
        //Реализация метода изменения директории
        public bool ChangePath(string path)
        {
            //проверка на null
            if (path == null)
            {//в случае True выводит на экран перечень жестких дисков 
                DiskList();
             //с установкой курсора на первый элемент.
                First();
            }
            else if (Directory.Exists(path))
            {// в случае если путь существует, вызывает метод по получению всех его директорий и файлов
                ItemList(path);
                //с установкой курсора на первом элементе.
                First();
                return true;
            }
            return false;
        }

        //Реализация метода отображения списка жестких дисков компьютера
        private void DiskList()
            //Создание списка класса "Свойства элементов"
        {
            List<MainProperties> list = new List<MainProperties>();
            try
            {//получения дисков (метод возвращает массив строк, содержащий имена логических дисков)
                foreach (var disk in Environment.GetLogicalDrives())
                {
                    try
                    {//Создание переменной как новый класс "Свойства элементов"
                        var item = new MainProperties()
                        {//Добавление свойств пути и имени
                            MainPath = disk,
                            Name = disk
                        };
                        //наполнение списка
                        list.Add(item);

                    }
                    catch { }
                }
            }
            catch { }
            //сортировка по типу (директория/файл), затем по имени
            Items = list.OrderBy(o => o.Name).ToList();

        }

        //Отображает содержимое выбранной директории
        private void ItemList(string path)
        {//Создание списка класса "Свойства элементов"
            List<MainProperties> list = new List<MainProperties>();
            try
            {//получения содержимого (метод возвращает имена всех файлов и подкаталогов)
                foreach (var entri in Directory.GetFileSystemEntries(path))
                {
                    try
                    {//Создание переменной как новый класс "Свойства элементов"
                        var item = new MainProperties()
                        {//Добавление свойств пути и имени, а так же размера
                            MainPath = entri,
                            Name = Path.GetFileName(entri),
                            //Размер при помощи тернарного оператора проверяем существование файла и данные о его размере
                            Size = File.Exists(entri) ? new FileInfo(entri).Length : (long?)null
                        };
                        //наполнение списка
                        list.Add(item);
                    }
                    //Отлавливание исключений
                    catch (Exception)
                    {
                        Console.WriteLine("Операция не удалась!");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Операция не удалась!");
            }
            //сортировка по типу (директория/файл), затем по имени
            Items = list.OrderBy(o => o.Size.HasValue).ThenBy(o => o.Name).ToList();
            //Создание  перехода к предыдущей директории
            var PreviousPath = new MainProperties() { Name = "back" };
            var parent = Directory.GetParent(path);
            if (parent != null && !parent.FullName.Equals(path))
                PreviousPath.MainPath = parent.FullName;
            Items.Insert(0, PreviousPath);

        }

        //Установка курсора на первом элементе списка
        public void First()
        {
            try
            {
                Selected = Items[0];
            }
            //Отлавливание исключений
            catch { }
        }

        //Установка курсора на последнем элементе списка
        public void Last()
        {
            try
            {
                Selected = Items[Items.Count - 1];
            }
            //Отлавливание исключений
            catch { }

        }


        //Открытие выбранной директории
        public bool Open()
        {//Проверка на существование пути
            if (Selected != null)
                return ChangePath(Selected.MainPath);
            else
                return false;
        }

        //Реализация навигации по дереву файлового менеджера
        public void Previous()
        {
            var index = Items.FindIndex(o => o.Equals(Selected));
            Selected = index <= 0 ? Items[0] : Items[index - 1];
        }
        //Реализация навигации по дереву файлового менеджера
        public void Next()
        {
            var index = Items.FindIndex(o => o.Equals(Selected));
            Selected = index >= Items.Count - 1 ? Items[Items.Count - 1] : Items[index + 1];

        }
        //Реализация команды копирование файла
        public void СopyFile()
        {//очистка консоли, вывод сообщения, запрос ввода пути коирования с указанием имени копируемого файла
            Console.Clear();
            Console.WriteLine("Введите путь копирования файла:");
            var input = Console.ReadLine();
            try
            {
                //Проверка выбранного файла на null
                if (Selected != null && !Items.First().Equals(Selected) && Selected.Size.HasValue)
                    //Операция копирования
                    File.Copy(Selected.MainPath, input, true);
                //Вывод сообщения об успешном копировании
                Console.WriteLine($"Файл {Selected.Name} успешно скопирован в {input}!");
                Console.ReadKey();
                //возврат к предыдущему элементу списка (установка курсора)
                Previous();

            }
            //Отлавливание исключений
            catch (Exception)
            {
                Console.WriteLine("Операция не удалась!"); ;
            }

        }
        //Реализация команды удаления файлов, каталогов
        public bool Delete()
        {
            if (Selected != null && !Items.First().Equals(Selected))
            {
                try
                {//Удаление файлов
                    if (Selected.Size.HasValue)
                        File.Delete(Selected.MainPath);
                    else
                        //Удаление директорий
                        Directory.Delete(Selected.MainPath, true);
                    //Удаление из списка
                    Items.Remove(Selected);
                    //возврат к предыдущему элементу списка (установка курсора)
                    Previous();
                    return true;
                }//Отлавливание исключений
                catch (Exception)
                {
                    Console.WriteLine("Операция не удалась!");
                }
            }
            return false;
        }
        //Реализация метода создания директории
        public void CreateDir()
        {//очистка консоли, вывод сообщения, запрос ввода пути создания директории
            Console.Clear();
            Console.WriteLine("Для создания дирректории введите её путь и её название:");
            var path = Console.ReadLine();
            try
            {//Проверка существования введенного пути создаваемой директории
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Такая директория уже создана!");
                    Console.ReadKey();
                    return;
                }
                //Создание директории, вывод соответствующего сообщения
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("Директория была успешно создана", Directory.GetCreationTime(path));
                Console.ReadKey();
                //возврат к предыдущему элементу списка (установка курсора)
                Previous();

            }
            //Отлавливание исключений
            catch (Exception)
            {
                Console.WriteLine("Операция не удалась!");
            }

        }
        //Реализация метода по перемещению файлов и директорий
        public void MoveDir()
        {//очистка консоли, вывод сообщения, запрос ввода пути перемещения файлов/директорий с указанием в пути имени
            Console.Clear();
            Console.WriteLine("Для  перемещения директории или файла введите путь назначения:");
            var path = Console.ReadLine();
            try
            {//Перемещение файлов
                if (Selected.Size.HasValue)
                {
                    File.Move(Selected.MainPath, path, true);
                    //вывод сообщения об успешном выполнении операции
                    Console.WriteLine($"Перенос {Selected.Name} успешно выполнен!");
                    Console.ReadKey();
                    //возврат к предыдущему элементу списка (установка курсора)
                    Previous();
                }

                else
                {//Перемещение директории
                    Directory.Move(Selected.MainPath, path);
                    //вывод сообщения об успешном выполнении операции
                    Console.WriteLine($"Перенос {Selected.Name} успешно выполнен!");
                    Console.ReadKey();
                    //возврат к предыдущему элементу списка (установка курсора)
                    Previous();
                }

            }//Отлавливание исключений
            catch (Exception)
            {
                Console.WriteLine("Операция не удалась!");
            }
        }
        //Вывод на экран список жестких дисков с установкой курсора на первом элементе
        public void Home()
        {
            DiskList();
            First();
        }
        //Выводит на экран список доступных команд в менеджере
        public void HelpMenu()
        {//Очистка консоли
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cписок команд:");
            //Создание двумерного массива
            string[,] HelpInfo = new string[,]
            {
                {"Клавиша Home", "Выводит на экран перечень жестких дисков компьютера"},
                {"Клавиша A", "Создание новой директории"},
                {"Клавиша M", "Перемещение файлов/директорий"},
                {"Клавиша C", "Копирование файлов"},
                {"Клавиша Del", "Удаление файлов/директорий"},
                {"Клавиша Page UP","Выделение первого элемента списка директорий/файлов"},
                {"Клавиша Page DN","Выделение последнего элемента списка директорий/файлов"},
                {"Клавиши UP DN", "Навигация по директориям/файлам"},
                {"Клавиша Enter","Переход в указанную директорию"},
                {"Клавиша D","Отображает информацию о жестких дисках"},
                {"Клавиша Q","Выход из приложения"}
            };
            //вывод двумерного массива на экран
            for (int i = 0; i < HelpInfo.GetLength(0); i++)
            {
                for (int j = 0; j < HelpInfo.GetLength(1); j++)
                {
                    Console.Write(HelpInfo[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Для продолжения, нажмите любую клавишу.");
            Console.ReadKey();
            Home();
        }

        //Вывод на экран информации о жестких дисках
        public void HDDInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сведения о жестких дисках:");
            //создание массива жестких дисков
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {//Вывод информации на экран
                Console.WriteLine("Диск {0}", d.Name);
                Console.WriteLine("  Тип Диска: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Наименование тома: {0}", d.VolumeLabel);
                    Console.WriteLine("  Файловая система: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Доступно свободного места: {0, 6} gb",
                        //Перевод из байтов в гигабайты
                        d.AvailableFreeSpace / 1024 / 1024 / 1024);

                    Console.WriteLine(
                        "  Всего:            {0, 15} gb ",
                        ////Перевод из байтов в гигабайты
                        d.TotalSize / 1024 / 1024 / 1024);
                }
            }
            Console.WriteLine("Для продолжения, нажмите любую клавишу.");
            Console.ReadKey();
            Home();
        }
        //Реализация выхода (закрытие приложения)
        public void Quit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"Вы действительно хотите выйти? 
Для продолжения нажмите Y, для отмены нажмите N.");
            //Привязка клавишь Y N к соответствующим действиям
            var Key = Console.ReadKey();
            //Случай закрытия приложения
            if (Key.Key==ConsoleKey.Y)
            {
                //Попытка реализации сериализации (не работает)
                Save();
                //Закрытие консоли
                Environment.Exit(0);
                
            }
            else if (Key.Key == ConsoleKey.Y)
            {//В случае отмены возвращает Вывод на экран список жестких дисков с установкой курсора на первом элементе
                Home();
                First();
            }
        }
        //Попытка реализации метода сериализации
        public void Save()
        {//создание переменной класса "Свойства элементов"
            var mainProperties = new MainProperties();
            //Вызов метода сериализации в строковую
            string objectSerialised = JsonSerializer.Serialize(mainProperties);
            //Запись данных в json файл
            File.WriteAllText("save_file.json", objectSerialised);
        }
        //Попытка реализации метода десериализации
        public void Load(out MainProperties mainPropertiesObject)
        {   //Чтение данных из json файла
            string objectJsonFile = File.ReadAllText("save_file.json");
            //Десереализация
            mainPropertiesObject = JsonSerializer.Deserialize<MainProperties>(objectJsonFile);

        }

    }
}
