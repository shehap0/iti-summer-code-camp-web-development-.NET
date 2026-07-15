using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Room
    {
        private int roomNumber;

        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public Room()
        {
            roomNumber = 0;
        }

        public Room(int _roomNumber)
        {
            roomNumber = _roomNumber;
        }

        public string PrintInfo()
        {
            return $"Room Number: {roomNumber}";
        }
    }
}
