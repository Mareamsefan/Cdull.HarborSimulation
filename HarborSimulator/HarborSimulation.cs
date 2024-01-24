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
        // Krav 1

        // Scenario 1: Creating a dock with name and size
        // Dock(KrissHavn, Medium)
        public Dock(String name, String size);

        // Scenario 2: Adding the created dock to harbor
        //
        public void AddDock(Dock dock);

        // Scenario 3: Create a piece of cargo
        public Cargo(String name, double weight);

        // Scenario 4: Create a dock for unloading/loading cargo
        public CargoHandlingDock(int number);

        // Scenario 5: Create a queue for waiting ships
        void CreateQueue(List<Ship>);

        // Scenario 6: Create a crane that moves cargo at a certain unloading/loading dock
        public Crane(String name, CargoHandlingDock cargoHandlingDock);

        // Scenario 7: Creating a number of spots for cargo to wait
        public CargoSpot(int number);

        // Scenario 8: Checks if a cargo spot is available or not
        void CargoSpotAvailable(Boolean free);

        // Scenario 9: Creates a ship with name and size
        public Ship(String name, String model, String size, Boolean docked, List<Cargo> CargoList, List<String> JSONFileList);

       // void UnloadContainersTo(int range, unloadingspot, crane);

        //void LoadContainersTo(int range, containerspot);

        // Krav 2

        // Scenario 1: Setting up a sailing

        /// <summary>
        /// Runs the simulation to start a sailing at a specific time. 
        /// </summary>
        /// <param name="datatime">The time in days and hours</param>
        public Sailing(DataSetDateTime datatime, Ship ship);

        // Scenario 2: Setting up a recurring sailing, either daily or weekly
        void RecurringSailing(Sailing sailing, Boolean weekly, Boolean daily);

        // Krav 3

        // Scenario 1: Initiates docking for a ship 
        void Docking(Dock dock, Ship ship, DataSetDateTime datatime);

        // Scenario 2: Saving ship history to a json file
        void SaveToJSONFile();

        // Scenario 3: Reads ship history from a json file
        void ReadFromJSONFile();








    }
   
}
