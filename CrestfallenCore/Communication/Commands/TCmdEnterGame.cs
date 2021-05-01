using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdEnterGame : Command
    {
        public const string Tag = "CmdEnterGame";
        public static string Construct() => $"{Tag}";
    }
}
