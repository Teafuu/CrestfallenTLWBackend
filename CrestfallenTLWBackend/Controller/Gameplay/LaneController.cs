﻿using CrestfallenTLWBackend.Model.Gameplay;
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
            Units = new List<Unit>();
            Towers = new List<ITower>();
            Grid = new Grid();
        }

        public void SpawnUnit(Unit unit)
        {
            Units.Add(unit);
        }

        public void PlaceTower(int index)
        {
            Towers.Add(PlaceholderTowers[index].Clone());
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
