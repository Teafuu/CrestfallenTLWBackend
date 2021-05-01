using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestSpawnUnit : Command
    {
        public const string Tag = "RequestSpawnUnit";

        public static string Construct(string unitId) => $"{Tag}:{unitId}";
    }
}
