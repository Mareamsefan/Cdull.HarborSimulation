using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarborSimulator
{
    internal class Ship
    {
        public String Name { get; }
        public bool Docked { get; private set; }
        public Cargo cargo { get; private set; }

        public String Size { get; private set; }

        public Ship(String name, String size)
        {
            Name = name;
            Size = size;
            Docked = false;
            cargo = null; 
        }
        public void DockAt(Dock dock)
        {
            Docked = true; 
        }
        public void LoadCargo(Cargo cargo)
        {
            cargo = cargo;
            Console.WriteLine($"{Name} loaded with {cargo.Name} ({cargo.Weight} kg).");
        }
        public void UnloadCargo()
        {
            if (cargo != null)
            {
                Console.WriteLine($"{Name} unloaded {cargo.Name}.");
                cargo = null;
            }
        }
    }
}
