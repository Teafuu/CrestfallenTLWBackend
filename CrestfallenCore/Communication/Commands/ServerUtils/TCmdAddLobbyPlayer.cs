using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdAddLobbyPlayer : Command
    {
        public const string Tag = "CmdAddLobbyPlayer";
        public static string Construct(string playerId, string nickname, string isLocal) => $"{Tag}:{playerId}:{nickname}:{isLocal}";
    }
}
