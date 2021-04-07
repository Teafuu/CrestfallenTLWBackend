using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Interfaces
{
    public interface ITower
    {
        public string Name { get; set; }
        public float Radius { get; set; }
        public abstract void Fire();
    }
}
