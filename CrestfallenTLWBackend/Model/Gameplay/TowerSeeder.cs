using CrestfallenTLWBackend.Controller.Gameplay;

namespace CrestfallenTLWBackend.Model.Gameplay;

public static class TowerSeeder
{
    public static void Seed(LaneController lane)
    {
        lane.PlaceholderTowers.Add(new BaseTower(
            name: "Basic Tower", 
            radius: 8, 
            attackRatio: 2, 
            damage: 20, 
            controller: lane, 
            tile: null));

        lane.PlaceholderTowers.Add(new BaseTower(
            name: "Fire Tower",
            radius: 8,
            attackRatio: 2,
            damage: 20,
            controller: lane,
            tile: null));

        lane.PlaceholderTowers.Add(new BaseTower(
            name: "Terra flower",
            radius: 8,
            attackRatio: 2,
            damage: 20,
            controller: lane,
            tile: null));

        lane.PlaceholderTowers.Add(new BaseTower(
            name: "Eramghurd tower",
            radius: 8,
            attackRatio: 2,
            damage: 20,
            controller: lane,
            tile: null));
    }
}