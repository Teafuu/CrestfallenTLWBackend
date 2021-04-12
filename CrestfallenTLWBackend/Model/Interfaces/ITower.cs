using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Interfaces
{
    public interface ITower
    {
        public string Name { get; set; }
        public float Radius { get; set; }
        public float AttackRatio { get; set; }
        public float Damage { get; set; }
        public Tile Tile { get; set; }
        public abstract void Fire();
        public abstract ITower Clone();
    }
}
