using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace CrestfallenTLWBackend.Model.Interfaces
{
    public interface INavigator
    {
        Grid Grid { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }
        List<Tile> Waypoints { get; set; }
        void CalculatePath(Tile start);
    }
}
