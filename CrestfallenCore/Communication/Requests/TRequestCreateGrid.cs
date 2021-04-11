using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestCreateGrid : Command
    {
        public const string Tag = "RequestCreateGrid";
        public static string Construct() => $"{Tag}";
    }
}
