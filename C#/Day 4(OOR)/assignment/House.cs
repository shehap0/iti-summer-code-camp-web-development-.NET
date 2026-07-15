using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class House
    {
        private string address;
        private Room room;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

        public House()
        {
            address = "";
            room = new Room();
        }

        public House(string _address, int _roomNumber)
        {
            address = _address;
            room = new Room(_roomNumber);
        }

        public string PrintInfo()
        {
            return $"Address: {address}, {room.PrintInfo()}";
        }
    }
}
