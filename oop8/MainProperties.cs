using System;
using System.Collections.Generic;
using System.Text;

namespace oop8
{//создание класса "Свойства элементов"
    public class MainProperties
    { // класс включвает в себя такие свойства как: путь элемента (значение может быть прочитано и записано)
        public string MainPath { get; set; }
        //Имя элемента (значение может быть прочитано и записано)
        public string Name { get; set; }
        //Размер элемента (значение может быть прочитано и записано) с проверкой на Null
        public long? Size { get; set; } = null;
    }
}
