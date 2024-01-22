using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarborSimulator
{
    internal class Cargo
    {
        public string Name { get; }
        public double Weight { get; }

        public Cargo(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
