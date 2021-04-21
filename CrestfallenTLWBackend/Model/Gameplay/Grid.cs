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
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Tile Start { get; set; }

        public Grid()
        {
            Rows = 48;
            Columns = 16;

            TilesAsList = new List<Tile>();

            Tiles = new Tile[Rows, Columns];
            int index = 0;
            for (int x = 0; x < Rows; x++) { 
                for (int y = 0; y < Columns; y++) { 
                    Tiles[x,y] = new Tile(x, y, index);
                    TilesAsList.Add(Tiles[x, y]);
                    index++;
                }
            }
            //bad testing purposes
            Start = TilesAsList[0];
            Goal = TilesAsList[TilesAsList.Count -1];
            //end of bad
            GroupTiles();
        }

        private void GroupTiles()
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Columns; y++)
                {
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Node, x - 1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Node, x - 1, y - 1);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Node, x, y - 1);

                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x - 1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x, y + 1);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x +1, y);
                    AddNeighbouringTile(Tiles[x, y], Tiles[x, y].Neighbours, x, y - 1);
                    
                }
        }

        private void AddNeighbouringTile(Tile originalTile, ICollection<Tile> collection, int xOffset, int yOffset)
        {
            if (xOffset < 0 || xOffset >= Rows ||
                    yOffset < 0 || yOffset >= Columns)
                    return;
            collection.Add(Tiles[xOffset, yOffset]);
        }

        public void PrintGrid()
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++) {
                    if (Tiles[x, y] == Goal)
                        Console.Write("# ");
                    else if (Tiles[x, y].IsOccupied)
                        Console.Write("B ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
