using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller.Gameplay
{
    public class GameSimulator
    {
        public List<LaneController> Lanes { get; set; } = new List<LaneController>();

        private Thread _simulationThread;
        private bool _isActive;
        private int _tickDuration;
        public GameHandler GameHandler { get; set; }
        public GameSimulator(GameHandler handler, int tickrate)
        {
            _simulationThread = new Thread(() => Simulation()) { IsBackground = true };
            _tickDuration = 1000 / tickrate;
            GameHandler = handler;
            Lanes.Add(new LaneController(GameHandler.Players[0], this));
            Lanes.Add(new LaneController(GameHandler.Players[1], this));
            Start();
        }
        
        public void Start() => _simulationThread.Start();
        public void Stop() => _isActive = false;

        public void SpawnUnit(int unitId, Player player)
        {
            Lanes.Where(x => x.Player != player).FirstOrDefault().SpawnUnit(unitId);
        }

        private void Simulation()
        {
            _isActive = true;
            while (_isActive)
            {
                Thread.Sleep(_tickDuration);
                foreach(var lane in Lanes)
                {
                    if(lane.Units.Count > 0)
                        lane.MoveUnits();
                    if(lane.Towers.Count > 0)
                        lane.FireTowers();
                }
            }
        }
    }
}
