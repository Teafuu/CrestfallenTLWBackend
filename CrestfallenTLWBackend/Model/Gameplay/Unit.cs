using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public abstract class Unit
    {
        public abstract Queue<Tile> Waypoints { get; set; }
    }
}
