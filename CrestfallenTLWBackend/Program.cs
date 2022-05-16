using CrestfallenTLWBackend.Controller;

namespace CrestfallenTLWBackend;

class Program
{
    static void Main(string[] args)
    {
        /*
        Grid grid = new Grid();
        Unit unit = new Unit(grid);
        unit.MovementSpeed = 1;
        unit.CalculatePath(grid.TilesAsList[0]);
        while (true)
        {
            unit.Move();
            unit.PrintPath();
            Console.WriteLine($"x: {unit.Position.X}\ny:{unit.Position.Y}");
            Thread.Sleep(1000);
            Console.Clear();
        }
        unit.PrintPath();
        Console.WriteLine("Path calculated");
        */

        new ServerHandler();
    }

}