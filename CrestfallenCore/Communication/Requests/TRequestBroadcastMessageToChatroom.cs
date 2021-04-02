using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestBroadcastMessageToChatroom : Command
    {
        public const string Tag = "RequestBroadcastMessageToChatroom";
        public static string Construct(string chatroomID, string broadcaster, string message) => $"{Tag}:{chatroomID}:{broadcaster}:{message}";
    }
}
