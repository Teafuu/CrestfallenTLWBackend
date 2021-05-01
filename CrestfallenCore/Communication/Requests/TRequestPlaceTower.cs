using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenCore.Communication.Requests
{
    public abstract class TRequestPlaceTower : Command
    {
        public const string Tag = "RequestPlaceTower";

        public static string Construct(int col, int row) => $"{Tag}:{row}:{col}";
    }
}
