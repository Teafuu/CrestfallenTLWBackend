using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdOnConnected : Command
    {
        public const string Tag = "CmdOnConnected";
        public static string Construct(string playerID, string isLocal) => $"{Tag}:{playerID}:{isLocal}";
    }
}
