using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestPlaceTower : Command
    {
        public const string Tag = "RequestPlaceTower";

        public static string Construct(string row, string col, string playerId) => $"{Tag}:{row}:{col}:{playerId}";
    }
}
