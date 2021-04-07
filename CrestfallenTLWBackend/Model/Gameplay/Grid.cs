using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class Grid
    {
        public Tile[,] Tiles { get; set; }
        private int _xLength;
        private int _yLength;
        public Grid()
        {
            _xLength = 16;
            _yLength = 8;

            Tiles = new Tile[_xLength, _yLength];
            for (int x = 0; x < _xLength; x++)
                for (int y = 0; y < _yLength; y++)
                    Tiles[x,y] = new Tile(x, y);
            GroupTiles();
        }

        private void GroupTiles()
        {
            for (int x = 0; x < _xLength; x++)
                for (int y = 0; y < _yLength; y++)
                {
                    AddNeighbouringTile(Tiles[x, y], Tiles[x,y].TileBlock, x - 1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].TileBlock, x - 1, y - 1);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].TileBlock, x, y - 1);

                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x - 1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x, y + 1);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x +1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x, y - 1);
                }
        }

        private void AddNeighbouringTile(Tile originalTile, ICollection<Tile> collection, int xOffset, int yOffset)
        {
            if (xOffset < 0 || xOffset > _xLength ||
                yOffset < 0|| yOffset > _yLength)
                return;
            collection.Add(Tiles[xOffset, yOffset]);
        }

        public void PrintGrid()
        {
            for (int x = 0; x < _xLength; x++)
            {
                for (int y = 0; y < _yLength; y++)
                    Console.Write("* ");
                Console.WriteLine();
            }
        }
    }
}
