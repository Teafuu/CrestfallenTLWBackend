using System;
using System.Drawing;
using CrestfallenTLWBackend.Controller;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;

namespace CrestfallenTLWBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();
            Unit unit = new Unit(grid);
            unit.CalculatePath(grid.TilesAsList[0]);
            unit.PrintPath();
            Console.WriteLine("Path calculated");
        }

    }
}
