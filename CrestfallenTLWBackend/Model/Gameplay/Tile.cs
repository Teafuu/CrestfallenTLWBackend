using CrestfallenTLWBackend.Model.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class Tile
    {
        public List<Tile> TileBlock { get; set; }
        public List<Tile> Neighbours { get; set; }
        public ITower Tower { get; set; }
        public bool IsBlocked { get; set; }

        public Vector2 Position;
        public int Index { get; set; }

        public Tile(int x, int y, int index)
        {
            TileBlock = new List<Tile>();
            Neighbours = new List<Tile>();
            TileBlock.Add(this);
            Position.X = x;
            Position.Y = y;
            Index = index;
        }
    }
}