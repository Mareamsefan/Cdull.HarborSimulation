using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HarborSimulator
{
    internal interface HarborSimulation
    {
        void CreateHarbor(int Docks, int UnloadingPlaces, int WaitingPlaces, ); 
        /// <summary>
        /// Runs the simulation to start a sailing at a specific time. 
        /// </summary>
        /// <param name="datatime">The time in days and hours</param>
        void Sailing(DataSetDateTime datatime, String model);

        void RecurringSailing(Sailing sailing, Boolean weekly, Boolean daily);

        void Docking(String model); 


      



    }
}
