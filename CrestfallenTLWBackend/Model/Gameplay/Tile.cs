using CrestfallenTLWBackend.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CrestfallenTLWBackend.Model.Gameplay;

public class Tile
{
    public List<Tile> Node { get; set; } // Tower placement
    public List<Tile> Neighbours { get; set; } // Pathfinding
    public ITower Tower { get; set; } // Which tower is placed
    public bool IsOccupied { get; set; } // if a tower is placed

    public Vector2 Position; // Position in Matrix
    public int Index { get; set; } // Position in List

    public Tile(int x, int y, int index)
    {
        Node = new List<Tile>();
        Neighbours = new List<Tile>();
        Node.Add(this);
        Position.X = x;
        Position.Y = y;
        Index = index;
    }

    public bool Placeable => Node.Where(x => !x.IsOccupied).ToList().Count == 4;
}