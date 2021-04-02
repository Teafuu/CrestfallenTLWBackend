using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdEnterLobby : Command
    {
        public const string Tag = "CmdEnterLobby";
        public static string Construct(string opponentNickname, string chatroomID) => $"{Tag}:{opponentNickname}:{chatroomID}";
    }
}
