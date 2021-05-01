using CrestfallenTLWBackend.Controller.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public static class UnitSeeder
    {
        public static void Seed(LaneController lane)
        {
            lane.PlaceholderUnits.Add(new Unit(null) {
                CurrentHealth = 100,
                Id = 0,
                MovementSpeed = 0.1f,
                OriginalHealth = 100 
            });
        }
    }
}
