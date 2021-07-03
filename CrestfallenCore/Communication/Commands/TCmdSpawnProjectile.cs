using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdSpawnProjectile : Command
    {
        public const string Tag = "CmdSpawnProjectile";

        public static string Construct(string playerId, string towerKey, string unitKey) => $"{Tag}:{playerId}:{towerKey}:{unitKey}";
    }
}
