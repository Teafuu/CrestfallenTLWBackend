using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CrestfallenTLWBackend.Model.Gameplay
{
    class Unit : INavigator
    {
        public Grid Grid { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public List<Tile> Waypoints { get; set; }

        public Unit(Grid grid)
        {
            Grid = grid;
            Waypoints = new List<Tile>();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void CalculatePath(Tile start) => ReconstructPath(start, Solve(start));

        private Tile[] Solve(Tile start)
        {
            Queue<Tile> q = new Queue<Tile>();

            q.Enqueue(start);

            bool[] visited = new bool[Grid.TilesAsList.Count];
            visited[start.Index] = true;

            Tile[] recordedResult = new Tile[Grid.TilesAsList.Count];

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                foreach (var next in node.Neighbours)
                    if (!visited[next.Index])
                        if (!next.IsBlocked) { 
                            q.Enqueue(next);
                            visited[next.Index] = true;
                            recordedResult[next.Index] = node;
                            if (next == Grid.Goal)
                                return recordedResult;
                        }
            }
            return recordedResult;
        }
        private bool ReconstructPath(Tile start, Tile[] recordedResult)
        {
            Waypoints.Clear();

            for(Tile tile = Grid.Goal; tile != null; tile = recordedResult[tile.Index])
                Waypoints.Add(tile);

            Waypoints.Reverse();

            if (Waypoints.Count > 0)
                return Waypoints[0] == start;
            else return false;
        }
        public void PrintPath()
        {
            for (int x = 0; x < Grid.XLength; x++)
            {
                for (int y = 0; y < Grid.YLength; y++)
                {
                    if (Grid.Tiles[x, y] == Grid.Goal)
                        Console.Write("# ");
                    else if (Waypoints.Contains(Grid.Tiles[x, y]))
                        Console.Write(". ");
                    else if (Grid.Tiles[x, y].IsBlocked)
                        Console.Write("B ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
