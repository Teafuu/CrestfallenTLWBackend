using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdSpawnUnit : Command
    {
        public const string Tag = "CmdSpawnUnit";
        /// <summary>
        /// PlayerId Being the one who receives the unit.
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static string Construct(string playerId, string unitId, string keyCount, string x, string y) => $"{Tag}:{playerId}:{unitId}:{keyCount}:{x}:{y}";
    }
}
