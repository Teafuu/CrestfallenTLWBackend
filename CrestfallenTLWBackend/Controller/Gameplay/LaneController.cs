using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Controller.Gameplay
{
    public class LaneController
    {
        public List<Unit> Units { get; set; }
        public List<ITower> Towers { get; set; }
        public List<BaseTower> PlaceholderTowers { get; set; }
        public Grid Grid { get; set; }

        private Player _player;
        public LaneController(Player player)
        {
            _player = player;
            TowerSeeder.Seed(this);
            Units = new List<Unit>();
            Towers = new List<ITower>();
            Grid = new Grid();
        }

        public void SpawnUnit(Unit unit)
        {

        }

        public void PlaceTower(int row, int col, int index)
        {
            if(Grid.Tiles[row, col].Placeable)
            {
                ITower tower = PlaceholderTowers[index].Clone();
                tower.Tile = Grid.Tiles[row, col];

                foreach (var tile in Grid.Tiles[row, col].Node)
                    tile.IsOccupied = true;

                Towers.Add(tower);

                //då måste vi skapa ett command, som sæger åt unity att spawna tornet
            }
        }

        public void MoveUnits() // Whacky race condition solution
        {
            var task = Parallel.ForEach(Units, x => x.Move());
            while (!task.IsCompleted)
                continue;
            return;
        }

        public void FireTowers()
        {
            var task = Parallel.ForEach(Towers, x => x.Fire());
            while (!task.IsCompleted)
                continue;
            return;
        }
    }
}
