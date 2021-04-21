using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Commands.Gameplay
{
    public class CmdUpdateUnitPositions : TCmdUpdateUnitPositions
    {
        private readonly string units;
        private readonly Player player;

        public CmdUpdateUnitPositions(string units, Player player)
        {
            this.units = units;
            this.player = player;
        }
        public override void Execute() => player.Output(Construct(units));
    }
}
