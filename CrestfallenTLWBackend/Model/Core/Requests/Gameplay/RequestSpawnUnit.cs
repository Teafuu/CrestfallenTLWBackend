using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Requests.Gameplay
{
    public class RequestSpawnUnit : TRequestSpawnUnit
    {
        private readonly int unitId;
        private readonly Player player;

        public RequestSpawnUnit(string unitId, Player player)
        {
            this.unitId = Convert.ToInt32(unitId);
            this.player = player;
        }

        public override void Execute()
        {
            player.GameHandler.Simulator.SpawnUnit(unitId, player);
        }
    }
}
