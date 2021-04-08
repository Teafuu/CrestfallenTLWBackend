using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class Grid
    {
        public Tile[,] Tiles { get; set; }
        public List<Tile> TilesAsList { get; set; }
        public Tile Goal;
        public int XLength { get; set; }
        public int YLength { get; set; }
        public Grid()
        {
            XLength = 16;
            YLength = 8;

            TilesAsList = new List<Tile>();

            Tiles = new Tile[XLength, YLength];
            int index = 0;
            for (int x = 0; x < XLength; x++) { 
                for (int y = 0; y < YLength; y++) { 
                    Tiles[x,y] = new Tile(x, y, index);
                    TilesAsList.Add(Tiles[x, y]);
                    index++;
                }
            }

            TilesAsList[1].IsBlocked = true;
            Goal = TilesAsList[125];
            GroupTiles();
        }

        private void GroupTiles()
        {
            for (int x = 0; x < XLength; x++)
                for (int y = 0; y < YLength; y++)
                {
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].TileBlock, x - 1, y);
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
            if (xOffset < 0 || xOffset >= XLength ||
                yOffset < 0 || yOffset >= YLength)
                return;
            collection.Add(Tiles[xOffset, yOffset]);
        }

        public void PrintGrid()
        {
            for (int x = 0; x < XLength; x++)
            {
                for (int y = 0; y < YLength; y++) {
                    if (Tiles[x, y] == Goal)
                        Console.Write("# ");
                    else if (Tiles[x, y].IsBlocked)
                        Console.Write("B ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
