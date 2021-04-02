using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestChangeNickname : Command
    {
        public const string Tag = "RequestChangeNickname";
        public static string Construct(string nick) => $"{Tag}:{nick}";

    }
}
