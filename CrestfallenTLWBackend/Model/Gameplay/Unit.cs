using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class Unit : INavigator
    {
        public Vector2 Position;
        private Vector2 MovementVector;
        public float MovementSpeed { get; set; }
        public float CurrentHealth{ get; set; }
        public float OriginalHealth{ get; set; }

        public Grid Grid { get; set; }
        public List<Tile> Waypoints { get; set; }
        private int _currentWaypointDestination;

        public Unit(Grid grid)
        {
            Grid = grid;
            Waypoints = new List<Tile>();
            _currentWaypointDestination = 0;
        }

        public void Move()
        {
            if(Vector2.Distance(Position, Waypoints[_currentWaypointDestination].Position) <= 0)
            {
                if (Waypoints.Count - 1 == _currentWaypointDestination)
                    Logger.Log($"{this} finished navigating");
                else
                {
                    Position = Waypoints[_currentWaypointDestination].Position;
                    _currentWaypointDestination++;
                    GetMovementDirection();
                }
            }
            Position += MovementVector;
        }

        internal void TakeDamage(float damage) => CurrentHealth -= damage;

        private void GetMovementDirection()
        {
            if ((Position.X - Waypoints[_currentWaypointDestination].Position.X) == 0)
            {
                if ((Position.Y - Waypoints[_currentWaypointDestination].Position.Y) > 0)
                {
                    MovementVector.Y = -MovementSpeed;
                    MovementVector.X = 0;
                }
                else
                {
                    MovementVector.Y = MovementSpeed;
                    MovementVector.X = 0;
                }
            }
            else
            {
                if ((Position.X - Waypoints[_currentWaypointDestination].Position.X) > 0)
                {
                    MovementVector.Y = 0;
                    MovementVector.X = -MovementSpeed;
                }
                else
                {
                    MovementVector.Y = 0;
                    MovementVector.X = MovementSpeed;
                }
            }
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
            Position = Waypoints[0].Position;
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
                    else if (Grid.Tiles[x, y].Position == Position)
                        Console.Write("P ");
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
