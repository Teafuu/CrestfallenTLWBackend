using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller.Gameplay
{
    public class GameSimulator
    {
        List<LaneController> Lanes { get; set; }

        private Thread _simulationThread;
        private bool _isActive;
        private int _tickDuration;
        private GameHandler _handler;
        public GameSimulator(GameHandler handler, int tickrate)
        {
            _simulationThread = new Thread(() => Simulation()) { IsBackground = true };
            _tickDuration = 1000 / tickrate;
            _handler = handler;

            Lanes.Add(new LaneController(_handler.Players[0]));
            Lanes.Add(new LaneController(_handler.Players[1]));
        }
        
        public void Start() => _simulationThread.Start();
        public void Stop() => _isActive = false;

        private void Simulation()
        {
            _isActive = true;
            while (_isActive)
            {
                Thread.Sleep(_tickDuration);
                foreach(var lane in Lanes)
                {
                    lane.MoveUnits();
                    lane.FireTowers();
                }
            }
        }
    }
}
