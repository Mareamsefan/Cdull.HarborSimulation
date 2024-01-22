using HarborSimulator;

class Program
{
    static void Main()
    {
        Harbor harbor = new Harbor();
        harbor.AddDock(new Dock("Dock1"));
        harbor.AddDock(new Dock("Dock2"));

        Ship ship1 = new Ship("Ship1");
        ship1.LoadCargo(new Cargo("Item1", 100));
        Ship ship2 = new Ship("Ship2");
        ship2.LoadCargo(new Cargo("Item2", 150));

        harbor.AddShip(ship1);
        harbor.AddShip(ship2);

        harbor.Simulate();
    }
}