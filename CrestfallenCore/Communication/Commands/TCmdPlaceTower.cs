using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdPlaceTower : Command
    {
        public const string Tag = "CmdPlaceTower";
        public static string Construct(string row, string col, string playerId, string towerId, string towerKey) => $"{Tag}:{col}:{row}:{playerId}:{towerId}:{towerKey}";
    }
}
