using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdPlaceTower : Command
    {
        public const string Tag = "CmdPlaceTower";
        public static string Construct(string row, string col, string playerId) => $"{Tag}:{col}:{row}:{playerId}";
    }
}
