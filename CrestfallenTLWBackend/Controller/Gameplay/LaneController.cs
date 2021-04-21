using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Controller.Gameplay
{
    public class LaneController
    {
        public Dictionary<int, Unit> Units { get; set; }
        public List<ITower> Towers { get; set; }
        public List<BaseTower> PlaceholderTowers { get; set; } = new List<BaseTower>();
        public List<Unit> PlaceholderUnits { get; set; } = new List<Unit>();
        public Grid Grid { get; set; }
        public GameSimulator Simulator { get; set; }
        private int _keyCount;
        public Player Player{ get; set; }
        public LaneController(Player player, GameSimulator simulator)
        {
            Player = player;
            Simulator = simulator;
            Units = new Dictionary<int, Unit>();
            Towers = new List<ITower>();
            Grid = new Grid();
            TowerSeeder.Seed(this);
            UnitSeeder.Seed(this);
            _keyCount = 0;
        }

        public void SpawnUnit(int unitId)
        {
            var unit = PlaceholderUnits[unitId].Clone();

            if (unit is null)
                return;

            unit.Key = _keyCount;
            unit.Grid = Grid;
            unit.CalculatePath(Grid.Start);
            Units.Add(_keyCount, unit);

            foreach (var player in Simulator.GameHandler.Players)
                player.GameHandler.CommandHandler.QueueCommand(CmdSpawnUnit.Construct(Player.ID.ToString(), unitId.ToString(), _keyCount.ToString(), Grid.Start.Position.X.ToString(), Grid.Start.Position.Y.ToString()), player);
            _keyCount++;
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
            }
        }

        public void MoveUnits() // Whacky race condition solution
        {
            string cmdMessage = "";
            var task = Parallel.ForEach(Units.Values, x => cmdMessage += x.Move()); //might not work..
            while (!task.IsCompleted)
                continue;

            foreach(var player in Simulator.GameHandler.Players)
                Simulator.GameHandler.CommandHandler.QueueCommand(CmdUpdateUnitPositions.Construct(cmdMessage), player);
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
