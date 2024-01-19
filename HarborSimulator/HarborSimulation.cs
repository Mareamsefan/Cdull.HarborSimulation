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
        void CreateDock(int number);

        void CreateUnloadingSpot(int number);
        // Gjelder både unloading og loading av containers

        void CreateWaitingSpot(int number);

        void CreateContainers(int number);

        void CreateCrane(int number);

        void CreateContainerSpot(int number);

        void ContainerSpotAvailable(Boolean free);

        void UnloadContainersTo(int range, unloadingspot, crane);

        void LoadContainersTo(int range, containerspot);
        



        /// <summary>
        /// Runs the simulation to start a sailing at a specific time. 
        /// </summary>
        /// <param name="datatime">The time in days and hours</param>
        void Sailing(DataSetDateTime datatime, String model);

        void RecurringSailing(Sailing sailing, Boolean weekly, Boolean daily);

        void Docking(String model); 


      



    }
}
