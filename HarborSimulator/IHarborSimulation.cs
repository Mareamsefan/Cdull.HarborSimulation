using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IHarborSimulator
{
    internal interface IHarborSimulation
    {
        // Krav 1

        // Scenario 0: Creating the harbor that is to be simulated
        // Kode eksempel; Harbor harbor = new Harbor(DockList, CargoList, ShipList);
        /*          harbor.AddDock(); 
         *          harbor.CreateShipQueue(); 
         *          harbor.
         */
        public Harbor(List<Dock> DockList, List<Cargo> CargoList, List<Ship> ShipList, 
            List<Crane> CraneList, List<CargoSpot> cargospot);

        // Scenario 1: Creating a dock with name, size and docktype
        // Dock(KrissHavn, Medium)
        public Dock(String name, String size, String dockType, int NumberOfCrane);

        // Scenario 2: Adding the created dock to harbor
        // kode
        /*  Harbor harbor = new Harbor(DockList, CargoList, ShipList);
            Dock dock = new Dock("dock1", "small", "normal", 3); 
         *  harbor.dockList.append(dock);
         */
        public void AddDock(Dock dock); 

        // Scenario 3: Create cargo
        public Cargo(String name, double weight);

        // Scenario 4: Create a dock for unloading/loading cargo
        public Dock(String name, String size, String dockType = "Cargohandlingdock");

        // Scenario 5: Create a queue for waiting ships
        // gjør det om til en kø etterpå, skal ligge i harbor: 
        void CreateShipQueue(List<Ship> ShipList);

        // Scenario 6: Create a crane that moves cargo at a certain unloading/loading dock

        public Dock(String name, String size, String dockType, int NumberOfCrane);

        //krav 8: venteplass for cargos

        // Scenario 7: Creating a number of spots for cargo to wait
        public CargoSpot(int number, bool IsAvailable = true);
        /* Harbor harbor = new Harbor(DockList, CargoList, ShipList, CargoSpotList);
         * for (int i = 0; i >= number; i++){
         *     CargoSpot cargo = new CargoSpot("cargo +{i}"); 
         * }
         */

        // Scenario 8: Legger til cargos i cargospots 
        // er i harbor klassen 
        void AddCargoToCargoSpot(Harbor.CargoSpotList, Ship.CargoList);

        // Scenario 9: Creates a ship with name and size
        // Se over og fjern JSON 
        public Ship(String name, String model, String size, Boolean docked, List<Cargo> CargoList, List<String> JSONFileList);

        void MoveCargoTo(int range, Harbor.CargoSpotList, crane);

        //void LoadContainersTo(int range, containerspot);

        // Krav 2

        // Scenario 1: Setting up a sailing
        public Sailing(DataSetDateTime datatime, Ship ship);
        /* 
         */

        // Scenario 2: Setting up a recurring sailing, either daily or weekly
        void RecurringSailing(Sailing sailing, Boolean weekly, Boolean daily);

        // Krav 3

        // Scenario 1: Initiates docking for a ship and saves history 
        void DockAt(Dock dock, DataSetDateTime datatime, SaveShipToJSONFile saveShipToJSONFile);
        /* kode eksempel: 
         * if(Ship.size == dock.size){
            If(dock.IsOccupied is false && ship.docked is false)
            {
                ship.docked = true;
                dock.IsOccupied = true;
                fileName = saveShipToJSONFile(ship, dock, datatime); 
                ship.HistoryList.append(fileName); 

            }
            else {
                queue.append(ship); 
                }
        }
        */ 
        // Krav 4

        // Scenario 1: Saving ship history to a json file
        delegate String SaveShipToJSONFile(Ship ship);

        // Scenario 2: Reads ship history from a json file
        // bruker delegate for å kunne passere metoden som en parameter? 
        delegate void ReadShipFromJSONFile(String filename);

        // Krav 5

        // Scenario 1: Saving cargo history to a json file
        delegate void SaveCargoToJSONFile(Cargo cargo);

        // Scenario 2: Reads cargo history from a json file
        delegate void ReadCargoFromJSONFile(String filename);

        // Krav 6 og krav 9: 

        //Scenario 1: 
        void AddToQueue(Ship ship, List<Ship> ShipList);

        // Krav 7 

        //Scenario 1: Measure time elapsed 
        // class for watch to measure time 
        public Watch(DataSetDateTime datatime);


        //Scenario 2: Start counting time 
        delegate void StartCountingTime();

        //Scenario 3: Stop counting time 
        delegate void StopCountingTime();

        //Scenario 4: measure the time that elapsed  
        void MeasureTimeElapsed(StartCountingTime startCountingTime, StopCountingTime stopCountingTime); 











    }

}
