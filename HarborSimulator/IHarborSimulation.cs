using Cdull.HarborSimulation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Cdull.HarborSimulation.IHarborSimulation;

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
        void MoveCargoToShip(Cargo Cargo, SaveCargoHistory saveCargoHistory);



        // Requriement 2 and 1: Configuration of sailing and elapsing time when sailing starts

        //Scenario 1: Ships can setup a sailing ( isSailing(true); )
        public void Ship(String name, String model, String size, bool HasDocked, List<Cargo> CargoList,
            String dockname, bool isSailing);

        // Scenario 2: Setting up a sailing 
        // Code example:
        // This method is in class Ship.
        /*  watch.startCountingTime();
         *  ship.IsSailing(true);
         */
        void Sailing(UnicodeEncoding id, DataSetDateTime datatime, Ship ship, Watch watch);
        /* 
         */

        // Scenario 3: Setting up a recurring sailing, either daily or weekly
        // code example: 
        /* This method is also in class Ship. 
         * if(IsWeekly){
         *      for(int i = 0; i < 1; i++){
         *          this.Sailing(); setting up a sailing 1 time in a week 
         *      }
         * }
         * if(IsDaily){
         *      for(int i = 0; i < 7; i++){
         *          this.Sailing();  setting up a sailing 7 times in a week 
         *      }
         * }
         * 
         */


        void RecurringSailing(Boolean IsWeekly, Boolean IsDaily);


        // Requirement 2 and 1: Configuration of docking, stopping time when docking stops and saving Shiphistory.


        //Scenario 1: Checks if dock with the required size is available.  
        delegate void CheckIfDockAvailable(bool IsAvailable, String size);
        /*foreach(dock in DockList){
         *     if (dock.size == size && IsAvailable)
         *          return True
         *     else 
         *          return False
         *  }
         */

        // Scenario 2: Initiates docking for a ship and saves history 
        void DockAt(Dock dock, DataSetDateTime datatime, Watch watch, CheckIfDockAvailable 
            checkIfDockAvailable);
        /* kode eksempel: 
         * if checkIfDockAvailable(
            {  
                this.docked = true;
                dock.IsOccupied = true;
                watch.StopCountingTime(); 
                watch.MeasureTimeElapsed(); 
                dock.IsOccupiedBy= Ship; 
                fileName = saveHistory(ship, dock, datatime); 
                this.HistoryList.append(fileName); 

            }
            else {
                harbor.queue.append(ship); 
                }
        }
        */




        // Requirement 4: Saving and collecting ship history:

        // Scenario 1: Collecting and saving history of where the ship docked 
        // code example: 
        delegate void SaveShipHistory();


        //Scenario 2: Saving history of where the ship docked in class ship
        public void Ship(String name, String model, String size, bool HasDocked, List<Cargo> CargoList, List<String> HistoryList, String dockname);




        // Requirement 5: Saving and collecting cargo history: 

        // Scenario 1: Collecting and saving history of which ship the cargo was on

        delegate void SaveCargoHistory();
        // void MoveCargoToShip(Cargo Cargo, SaveCargoHistory saveCargoHistory);

        // Scenario 2: Saving history of which ship the cargo was on
        public void Cargo(String name, double weight, List<String> HistoryList);



        // Requirement 6 og requirement 9: Configuration 

        //Scenario 1: 
        void AddToQueue(Ship ship, Queue<Ship> ShipQueue);


        // Requirement: 7 

        //Scenario 1: Measure time elapsed 
        // class for watch to measure time 
        public void Watch(DataSetDateTime startTime, DataSetDateTime stopTime, bool IsCounting);


        //Scenario 2: Start counting time 
        //Code example: 
        /* if (!IsCounting){
                sartTime = DateTime.Now; 
                IsCounting = true; 
        } else{
              console.writeline("time is already counting")
        }*/

         void StartCountingTime();




        //Scenario 3: Stop counting time 
        //Code example: 
        /* if (IsCounting){
                sartTime = DateTime.Now; 
                IsCounting = false; 
        } else{
              console.writeline("time is currently not counting")
        }*/
         void StopCountingTime();


        //Scenario 4: measure the time that elapsed
        //Code example:
        // is in class watch
        /* Timespan elapsedTime = this.stopTime - this.startTime; 
         * return elapsedTime; 
         */
         DateTime MeasureTimeElapsed();



       












    }

}
