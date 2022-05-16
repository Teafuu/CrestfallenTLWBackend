using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Controller.Gameplay;

public class LaneController
{
    public Dictionary<int, Unit> Units { get; set; }
    public Dictionary<int, ITower> Towers { get; set; }
    public List<BaseTower> PlaceholderTowers { get; set; } = new List<BaseTower>();
    public List<Unit> PlaceholderUnits { get; set; } = new List<Unit>();
    public Grid Grid { get; set; }
    public GameSimulator Simulator { get; set; }
    public Player Player{ get; set; }

    private int _keyCount;
    private int _towerKeyCount;

    public LaneController(Player player, GameSimulator simulator)
    {
        Player = player;
        Simulator = simulator;
        Units = new Dictionary<int, Unit>();
        Towers = new Dictionary<int, ITower>();
        Grid = new Grid();
        TowerSeeder.Seed(this);
        UnitSeeder.Seed(this);
        _keyCount = 0;
        _towerKeyCount = 0;
    }

    public void SpawnUnit(int unitId)
    {
        var unit = PlaceholderUnits[unitId].Clone();

        if (unit is null)
            return;

        unit.Key = _keyCount;
        unit.Grid = Grid;
        unit.CalculatePath(Grid.Start);
        unit.OnDeathEvent += OnUnitDeath;
        Units.Add(_keyCount, unit);

        foreach (var player in Simulator.GameHandler.Players)
        {
            player.GameHandler.CommandHandler.QueueCommand(
                TCmdSpawnUnit.Construct(
                    Player.ID.ToString(),
                    unitId.ToString(),
                    _keyCount.ToString(),
                    Grid.Start.Position.X.ToString(),
                    Grid.Start.Position.Y.ToString()),
                player);
        }
        _keyCount++;

    }

    public int PlaceTower(int row, int col, int index)
    {
        if (!Grid.Tiles[row, col].Placeable) return -1;

        var tower = PlaceholderTowers[index].Clone();
        tower.Tile = Grid.Tiles[row, col];

        foreach (var tile in Grid.Tiles[row, col].Node)
            tile.IsOccupied = true;

        tower.TowerKey = _towerKeyCount;
        Towers.Add(_towerKeyCount, tower);
        _towerKeyCount++;

        return tower.TowerKey;
    }

    public void MoveUnits() // Whacky race condition solution
    {
        var cmdMessage = "";
        var task = Parallel.ForEach(Units.Values.ToList(), x => cmdMessage += x.Move()); //might not work..

        while (!task.IsCompleted) {}

        foreach(var player in Simulator.GameHandler.Players)
        {
            if (cmdMessage != string.Empty)
            {
                Simulator.GameHandler.CommandHandler.QueueCommand(
                    TCmdUpdateUnitPositions.Construct(
                        Player.ID.ToString(),
                        cmdMessage),
                    player);
            }
        }
    }

    public void FireTowers() // bad solution, tower should have internal timer and then have a fire event.
    {
        var task = Parallel.ForEach(Towers.Values.ToList(), x => x.Fire()); // should be sent as a copy, in case list gets changed during execution

        while (!task.IsCompleted) {}
    }

    /// <summary>
    /// Hooks into eventhandler of Unit, invoked when units health falls below 0.
    /// </summary>
    /// <param name="unitKey"></param>
    private void OnUnitDeath(int unitKey) => Units.Remove(unitKey);
}