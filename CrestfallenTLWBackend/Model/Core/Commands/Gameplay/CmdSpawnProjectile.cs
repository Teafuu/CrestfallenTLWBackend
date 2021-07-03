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


        public CmdSpawnProjectile(Player player, string towerKey, string unitKey)
        {
            this.player = player;
            this.towerKey = towerKey;
            this.unitKey = unitKey;
        }
        public override void Execute() => player.Output(Construct(player.ID.ToString(), towerKey, unitKey));
    }
}
