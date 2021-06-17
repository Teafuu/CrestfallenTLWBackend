using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands.Gameplay
{
    public abstract class TCmdFireBullet : Command
    {
        public const string Tag = "CmdFireBullet";
        public static string Construct(string playerID, string towerKey, string unitID) => $"{Tag}:{playerID}:{towerKey}:{unitID}";
     }
}
