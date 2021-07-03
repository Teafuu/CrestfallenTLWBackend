using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdUpdateUnitPositions : Command
    {
        public const string Tag = "CmdUpdateUnitPositions";
        public static string Construct(string playerId, string UpdatedUnitPositions) => $"{Tag}:{playerId}:{UpdatedUnitPositions}";
    }
}
