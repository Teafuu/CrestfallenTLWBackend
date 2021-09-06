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
        public float MovementSpeed { get; set; }
        public float CurrentHealth{ get; set; }
        public float OriginalHealth{ get; set; }
        public Grid Grid { get; set; }
        public List<Tile> Waypoints { get; set; }
        public int Id { get; set; }
        public int Key { get; set; }
        
        public int CurrentWayPointDestination { get; set; }
        private Vector2 MovementVector;

        private bool FinishedNavigating;

        public delegate void DeathEventHandler(int unitKey);
        public event DeathEventHandler OnDeathEvent;


        public Unit(Grid grid)
        {
            Grid = grid;
            Waypoints = new List<Tile>();
            CurrentWayPointDestination = 0;
        }

        public string Move()
        {
            if (FinishedNavigating)
                return "";
            if(Vector2.Distance(Position, Waypoints[CurrentWayPointDestination].Position) <= 0.3)
            {
                if (Waypoints.Count - 1 == CurrentWayPointDestination) {
                    FinishedNavigating = true;
                    //Logger.Log($"{this} finished navigating");
                }
                else
                {
                    Position = Waypoints[CurrentWayPointDestination].Position;
                    CurrentWayPointDestination++;
                    GetMovementDirection();
                }
            }
            Position += MovementVector;
            return $"!{Key},{Position.X},{Position.Y}";

        }

        internal void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if(CurrentHealth <= 0) // invoke hooked events for destroying this unit.
                OnDeathEvent.Invoke(Key);

        }

        private void GetMovementDirection()
        {
            if ((Position.X - Waypoints[CurrentWayPointDestination].Position.X) == 0)
            {
                if ((Position.Y - Waypoints[CurrentWayPointDestination].Position.Y) > 0)
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
                if ((Position.X - Waypoints[CurrentWayPointDestination].Position.X) > 0)
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
                        if (!next.IsOccupied) { 
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
            Logger.Log($"Calculated path from: {start.Position.X},{start.Position.Y} -> {Waypoints.Last().Position.X},{Waypoints.Last().Position.Y}");
            if (Waypoints.Count > 0)
                return Waypoints[0] == start;
            else return false;
        }

        public void PrintPath()
        {
            for (int x = 0; x < Grid.Rows; x++)
            {
                for (int y = 0; y < Grid.Columns; y++)
                {
                    if (Grid.Tiles[x, y] == Grid.Goal)
                        Console.Write("# "); 
                    else if (Grid.Tiles[x, y].Position == Position)
                        Console.Write("P ");
                    else if (Waypoints.Contains(Grid.Tiles[x, y]))
                        Console.Write(". ");
                    else if (Grid.Tiles[x, y].IsOccupied)
                        Console.Write("B ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public Unit Clone() => MemberwiseClone() as Unit;
    }
}
