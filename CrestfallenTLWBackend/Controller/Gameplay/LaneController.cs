using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Controller.Gameplay
{
    class LaneController
    {
        public List<IUnit> Units { get; set; }
        public List<ITower> Towers { get; set; }
        public Grid Grid { get; set; }

        private Player _player;
        public LaneController(Player player)
        {
            _player = player;
            Units = new List<IUnit>();
            Towers = new List<ITower>();
            Grid = new Grid();
        }

        public void SpawnUnit(IUnit unit)
        {
            //some cool logic
            Units.Add(unit);
        }

        public void MoveUnits()
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
