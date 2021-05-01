using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Commands.Gameplay
{
    public class CmdSpawnUnit : TCmdSpawnUnit
    {
        private readonly string unitId;
        private readonly string x;
        private readonly string y;
        private readonly string playerId;
        private readonly string keyCount;
        private readonly Player player;

        public CmdSpawnUnit(string playerId, string unitId, string keyCount, string x, string y, Player player)
        {
            this.unitId = unitId;
            this.x = x;
            this.y = y;
            this.playerId = playerId;
            this.player = player;
            this.keyCount = keyCount;
        }
        public override void Execute() => player.Output(Construct(playerId, unitId, keyCount, x, y));
    }
}
