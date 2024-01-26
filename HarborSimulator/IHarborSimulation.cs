using Cdull.HarborSimulation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cdull.HarborSimulation
{
    internal interface IHarborSimulation
    {
        // -- Requirement 1: Structure of harbor 

        // Scenario 1: Creating the harbor that is to be simulated
        // Code example (constructure method): 
        /*Harbor harbor = new Harbor(DockList, ShipList, ShipQueue, CraneList, cargoStorageFacility);
         *          harbor.AddDock();
         *          harbor.AddShips(); 
         *          harbor.CreateShipQueue(); 
         *          harbor.AddCargoToStorage(); 
         *          harbor.CreateCranes(); 
         */

        public void Harbor(List<Dock> DockList, List<Ship> ShipList, Queue<Cargo> ShipQueue, 
            List<Crane> CraneList, List<CargoStorageFacility> cargoStorageFacility);



        // Scenario 2: Creating a dock with name, size, docktype and crane 
        // Mainly there is two docktypes: berths and cargoHandling * 
        // Code example: 
        /*    Dock dock1 = new Dock("dock1", "small", "cargoHandling", new Crane()/crane); 
         *    * berths = docks that does not include cargo handling only docking. 
         *    Dock dock1 = new Dock("dock1", "small", "berths", new Crane()/crane); 
         */
        // Requriement 6 --> handeling conflicts by adding IsAvalible
        public void Dock(String name, String size, String dockType, bool IsAvalible=true);


       

        // Scenario 3: Initializing a number of docks to harbor
        // kode
        /*  Harbor harbor = new Harbor(DockList, CargoList, ShipList);
            Dock dock = new Dock("dock1", "small", "normal", 3); 
         *  harbor.dockList.append(dock);
         */
        // Perhaps making a method that initiates number of docks in harbor? 
        public void InitializeDocks(int number, String docktype, Crane crane);




        // Scenario 4: Adding the dock to the Harbor: 
        public void AddDock(Dock dock);



        // not sure whether we need the method to add crane.. adds 
        public void AddCrane(Crane crane);




        // Scenario 5: Initializing a crane that can transfer cargos from/to ships. 
        // Requriement 6 --> handeling conflicts by adding IsCraneAvalible
        public void Crane(bool IsCraneAvalible=true, bool IsCraneOutOfFuntion=false);

        //



        // Scenario 6: Initializing number of cranes in harbor 
        // code example: 
        /* for (int i = 0; i < number; i++){
         *         foreach(var dock in DockList)
         *         {
         *              dock.AddCrane(); 
         *         }
         * }
         */
        public void InitializingCranes(int number, List<Dock> DockList);



       

        // Scenario 7: Initializing cargo that can be transfered to/from ship. 
        public void Cargo(String name, double weight);





        // Scenario 8: Create a dock for unloading/loading cargo
        public void Dock(String name, String size, String dockType = "CargohandlingDock");




        // Scenario 9: Initiate a queue for waiting ships
        //  
        void InitiateShipQueue(Queue<Ship> ShipQueue);




        // kanskje vi burde fjerne denne? 

        // Scenario 10: Initiate a crane on a dock that moves cargo at a cargoHandelingDock 

        public void Dock(String name, String size, String dockType, Crane crane, bool IsAvalible=true);


        // Scenario 11:  Initiates if Dock is occupied by a ship and which ship it's occupied by.

        public void Dock(String name, String size, String dockType, Crane crane, bool IsAvalible = true, Ship IsOccupiedBy=null);

        // String size in Ship satisfies requirement 3  
        // Scenario 12: Initiates a ships so that they later can be added to harbor 
        //dockname does not have to be initiated

        public void Ship(String name, String model, String size, bool HasDocked, List<Cargo> CargoList, String dockname);



        // Scenario 13:  Initializing ships in harbor: 
        // placed in Harbor

        void AddShips(Ship ship, List<Ship> ShipList);

        

        //Requirement 8 and 1: Structure of harbor and waiting area for cargo

        // Scenario 14: Creating a number of storage facility for cargo to wait
        /* Code example: 
         * Harbor harbor = new Harbor(DockList, CargoList, ShipList, CargoSpotList);
         * for (int i = 0; i >= number; i++){
         *     CargoStorageFacility = new CargoStorageFacility("cargo +{i}"); 
         * }
        */
        public void CargoStorageFacility(int number, bool IsAvailable = true);


        // Scenario 15: Moving Cargo from ship to cargoStorageFacilitys
        // Should be placed in Dock class: 
        void AddCargoToStorage(List<CargoStorageFacility> cargoStorageFacility, List<Cargo> CargoList, Crane crane);

        // Scenario 16: Moving Cargo to ship 
        // Should be placed in Dock class: 
        // Code example: 
        /* In class Dock: 
         * void MoveCargoTpoShip(Cargo cargo){
         *      Ship = this.isOccpupiedBy();
         *      Ship.CargoList.append(Cargo);
         * };
         
         */
        void MoveCargoToShip(Cargo Cargo);



        // Requriement 2 and 1: Configuration of sailing and elapsing time when sailing starts

        // Scenario 1: Setting up a sailing 
        // Code example: 
        /* watch.startCountingTime +++ */
        public void Sailing(UnicodeEncoding id, DataSetDateTime datatime, Ship ship, Watch watch);
        /* 
         */

        // Scenario 2: Setting up a recurring sailing, either daily or weekly
        // code example: 
        
      
        void RecurringSailing(Sailing sailing, Boolean Isweekly, Boolean IsDaily);


        // Requirement 2 and 1: Configuration of docking, stopping time when docking stops and saving Shiphistory.

        // Scenario 1: Initiates docking for a ship and saves history 
        void DockAt(Dock dock, DataSetDateTime datatime, Watch watch);
        /* kode eksempel: 
         * if(Ship.size == dock.size){
            If(dock.IsOccupied is false && ship.docked is false)
            {
                ship.docked = true;
                dock.IsOccupied = true;
                watch.StopCountingTime(); 
                watch.MeasureTimeElapsed(); 
                dock.IsOccupiedBy= Ship; 
                fileName = saveHistory(ship, dock, datatime); 
                this.HistoryList.append(fileName); 

            }
            else {
                queue.append(ship); 
                }
        }
        */


        // Requirement 4: Saving and collecting ship history: 
        // code exapmple
        delegate void SaveShipHistory();

        public void Ship(String name, String model, String size, bool HasDocked, List<Cargo> CargoList, List<String> HistoryList, String dockname);

        // Requirement 5: Saving and collecting cargo history: 


        delegate void SaveCargoHistory();
        // to collect history of Cargo, just use the get method for 
        // Scenario 7: Initializing cargo that can be transfered to/from ship. 
        public void Cargo(String name, double weight, List<String> HistoryList);

        // Requirement 6 og requirement 9: 

        //Scenario 1: 
        void AddToQueue(Ship ship, List<Ship> ShipList);


        // Requirement: 7 

        //Scenario 1: Measure time elapsed 
        // class for watch to measure time 
        public void Watch(DataSetDateTime datatime);


        //Scenario 2: Start counting time 
        delegate void StartCountingTime();

        //Scenario 3: Stop counting time 
        delegate void StopCountingTime();

        //Scenario 4: measure the time that elapsed  
        delegate void MeasureTimeElapsed(StartCountingTime startCountingTime, StopCountingTime stopCountingTime);



       


      


      










    }

}
