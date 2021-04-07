using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace CrestfallenTLWBackend.Model.Interfaces
{
    interface INavigator
    {
        Grid Grid { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }

        public Dictionary<Tile, Tile> CameFrom { get; set; }
        public Dictionary<Tile, double> CostSoFar { get; set; }

        Queue<Tile> Waypoints { get; set; }

        Tile Goal { get; set; }

        public void CalculatePath(Tile start)
        {
            var frontier = new SimplePriorityQueue<Tile>();
            CameFrom = new Dictionary<Tile, Tile>();
            CostSoFar = new Dictionary<Tile, double>();
            frontier.Enqueue(start, 0);

            CameFrom[start] = start;
            CostSoFar[start] = 0;

            while(frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current.Equals(Goal))
                    break;

                foreach(var next in current.Neighbours)
                {
                    //how to calculate cost plez
                }
            }
        }

        static public double Heuristic(Tile a, Tile b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        public void Move()
        {

        }

    }
}
