using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdChangeReadyStatus : Command
    {
        public const string Tag = "CmdChangeReadyStatus";
        public static string Construct(string isReady) => $"{Tag}:{isReady}";
    }
}
