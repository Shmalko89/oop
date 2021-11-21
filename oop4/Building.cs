using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop4
{
    class Building
    {
        public Building()
        {
            _buildingNumber = RandomNumber();
        }
        private static int _number;

        private int _buildingNumber;

        private int _buildingHeight;

        private int _floorCount;

        private int _flatCount;

        private int _entranceCount;

        public int BuildingNumber { get => _buildingNumber; }

        public int BuildingHeight { get => _buildingHeight; set => _buildingHeight = value; }

        public int FloorCount { get => _floorCount; set => _floorCount = value; }

        public int FlatCount { get => _flatCount; set => _flatCount = value; }
        public int EntranceCount { get => _entranceCount; set => _entranceCount = value; }

        public static int RandomNumber()
        {
            return _number++;
        }

        public int FloorHeight()
        {
            if (_floorCount != 0)
                return _buildingHeight / _floorCount;
            return 0;
        }

        public int FlatInEntrance()
        {
            if (_entranceCount != 0)
                return _flatCount / _entranceCount;
            return 0;
        }

        public int FlatOnTheFloor()
        {
            if (_floorCount != 0)
                return FlatInEntrance() / _floorCount;
            return 0;
        }




    }
}
