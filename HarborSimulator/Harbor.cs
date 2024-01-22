using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarborSimulator
{
    internal class Harbor
    {
        private List<Dock> docks = new List<Dock>();
        private List<Ship> ships = new List<Ship>();

        public void AddDock(Dock dock)
        {
            docks.Add(dock); 
        } 

        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }
        public void Simulate()
        {
            foreach(Ship ship in ships)
            {
                Dock dock = GetAvailableDock(); 
                if (dock != null)
                {
                    dock.DockShip(ship);
                    Console.WriteLine($"{ship.Name} docked at {dock.Name}");
                    ship.UnloadCargo(); 
                }
                else
                {
                    Console.WriteLine($"{ship.Name} couldn't dock. No available docks.");
                }
            }
        }
        private Dock GetAvailableDock()
        {
            foreach (Dock dock in docks)
            {
                if (!dock.IsOccupied)
                {
                    return dock;
                }
            }
            return null;
        }
    }

 
}
