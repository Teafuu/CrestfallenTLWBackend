using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Commands.Gameplay
{
    public class CmdSpawnProjectile : TCmdSpawnProjectile
    {
    
        private readonly Player player;
        private readonly string towerKey;
        private readonly string unitKey;
        private readonly string playerID;

        public CmdSpawnProjectile(string playerID, string towerKey, string unitKey, Player player)
        {
            this.player = player;
            this.playerID = playerID;

            this.towerKey = towerKey;
            this.unitKey = unitKey;
        }
        public override void Execute()
        {
            foreach(var player  in player.GameHandler.Players)
                player.Output(Construct(playerID, towerKey, unitKey));
        }
    }
}
