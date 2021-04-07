﻿using CrestfallenTLWBackend.Model.Interfaces;
using System.Collections.Generic;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class Tile
    {
        public List<Tile> TileBlock { get; set; }
        public List<Tile> Neighbours { get; set; }
        public ITower Tower { get; set; }
        public bool IsBlocked { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Tile(int x, int y)
        {
            TileBlock = new List<Tile>();
            TileBlock.Add(this);
            X = x;
            Y = y;
        }
    }
}