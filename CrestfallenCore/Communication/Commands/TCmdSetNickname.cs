using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdSetNickname : Command
    {
        public const string Tag = "CmdSetNickname";
        public static string Construct(string nick) => $"{Tag}:{nick}";

    }
}
