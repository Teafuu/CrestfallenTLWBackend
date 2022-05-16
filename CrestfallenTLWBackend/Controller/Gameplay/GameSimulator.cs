using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CrestfallenTLWBackend.Controller.Gameplay;

public class GameSimulator
{
    public List<LaneController> Lanes { get; set; } = new();

    private readonly Thread _simulationThread;
    private bool _isActive;
    private readonly int _tickDuration;
    public GameHandler GameHandler { get; set; }
    private DateTime _timeSinceLastTick;
    public GameSimulator(GameHandler handler, int tickrate)
    {
        _simulationThread = new Thread(Simulation) { IsBackground = true };
        _tickDuration = 1000 / tickrate;
        _timeSinceLastTick = DateTime.Now;
        GameHandler = handler;

        Lanes.Add(new LaneController(GameHandler.Players[0], this));
        Lanes.Add(new LaneController(GameHandler.Players[1], this));

        Start();
    }

    public void Start() => _simulationThread.Start();
    public void Stop() => _isActive = false;

    public void SpawnUnit(int unitId, Player player)
    {
        Lanes.FirstOrDefault(x => x.Player != player)?.SpawnUnit(unitId);
    }

    public int PlaceTower(int row, int column, int towerId, Player player) 
        => Lanes.FirstOrDefault(x => x.Player == player)!.PlaceTower(row, column, towerId);


    private void Simulation()
    {
        _isActive = true;
        while (_isActive)
        {
            Thread.Sleep(_tickDuration); // FIX
            foreach(var lane in Lanes)
            {
                if (lane.Units.Count > 0)
                    lane.MoveUnits();
                if (lane.Towers.Count > 0)
                    lane.FireTowers();
            }
        }
    }
}