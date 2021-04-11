using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdCreateGrid : Command
    {
        public const string Tag = "CmdCreateGrid";
        public static string Construct(string rows, string columns) => $"{Tag}:{rows}:{columns}";
    }
}
