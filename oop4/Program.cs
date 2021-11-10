using System;

namespace oop4
{
    class Program
    {
        static void Main(string[] args)
        {
            var building = new Building();
            building.FloorCount = 5;
            building.FlatCount = 100;
            building.EntranceCount = 5;
            building.BuildingHeight = 25;

            Console.WriteLine("Технический паспорт здания:");
            Console.WriteLine($"Номер здания: {building.BuildingNumber}");
            Console.WriteLine($"Колличество этажей: {building.FloorCount} этажей;");
            Console.WriteLine($"Колличество квартир: {building.FlatCount} квартир;");
            Console.WriteLine($"Колличество подъездов: {building.EntranceCount} подъездов;");
            Console.WriteLine($"Высота этажа: {building.FloorHeight()} метров;");
            Console.WriteLine($"Колличество квартир в подъезде: {building.FlatInEntrance()} квартир;");
            Console.WriteLine($"Колличество квартир на этаже: {building.FlatOnTheFloor()} квартир.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
