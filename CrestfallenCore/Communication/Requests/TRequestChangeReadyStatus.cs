using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestChangeReadyStatus : Command
    {
        public const string Tag = "RequestChangeReadyStatus";
        public static string Construct(string readyStatus) => $"{Tag}:{readyStatus}";
    }
}
