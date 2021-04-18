using CrestfallenTLWBackend.Controller.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public static class TowerSeeder
    {
        public static void Seed(LaneController lane)
        {
            lane.PlaceholderTowers.Add(new BaseTower(
                name: "Basic Tower", 
                radius: 2, 
                attackRatio: 2, 
                damage: 20, 
                controller: lane, 
                tile: null));

            lane.PlaceholderTowers.Add(new BaseTower(
                name: "Fire Tower",
                radius: 2,
                attackRatio: 2,
                damage: 20,
                controller: lane,
                tile: null));

            lane.PlaceholderTowers.Add(new BaseTower(
                name: "Terra flower",
                radius: 2,
                attackRatio: 2,
                damage: 20,
                controller: lane,
                tile: null));

            lane.PlaceholderTowers.Add(new BaseTower(
                name: "Eramghurd tower",
                radius: 2,
                attackRatio: 2,
                damage: 20,
                controller: lane,
                tile: null));
        }
    }
}
