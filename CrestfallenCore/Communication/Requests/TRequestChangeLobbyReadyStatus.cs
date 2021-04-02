using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestChangeLobbyReadyStatus : Command
    {
        public const string Tag = "RequestChangeLobbyReadyStatus";
        public static string Construct(string readyStatus) => $"{Tag}:{readyStatus}";
    }
}
