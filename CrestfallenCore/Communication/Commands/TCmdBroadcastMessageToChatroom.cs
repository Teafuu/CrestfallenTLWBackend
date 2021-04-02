using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdBroadcastMessageToChatroom : Command
    {
        public const string Tag = "CmdBroadcastMessageToChatroom";
        public static string Construct(string chatroomID, string broadcaster, string message) => $"{Tag}:{chatroomID}:{broadcaster}:{message}";

    }
}
