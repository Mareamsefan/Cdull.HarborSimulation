using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarborSimulator
{
    internal class Dock
    {
        public String Name { get; }
        public bool IsOccupied { get; private set; }

        public Dock(String name)
        {
            Name = name;
            IsOccupied = false; 
        }
        public void DockShip(Ship ship)
        {
            IsOccupied = true;
            ship.DockAt(this); 
        }
    }
}
