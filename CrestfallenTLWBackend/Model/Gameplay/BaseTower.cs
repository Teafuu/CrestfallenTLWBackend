using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public abstract class BaseTower : ITower
    {
        public string Name { get; set; }
        public float Radius { get; set ; }

        public abstract void Fire();
    }
}
