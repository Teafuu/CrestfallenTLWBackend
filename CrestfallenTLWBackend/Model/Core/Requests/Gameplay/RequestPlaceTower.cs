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
    class RequestPlaceTower : TRequestPlaceTower
    {
        private readonly int row;
        private readonly int column;
        private Player _player;
        private int _playerId;
        private int _towerId;
        public RequestPlaceTower(string row, string column, string playerId, string towerId, Player player)
        {
            this.row = Convert.ToInt32(row);
            this.column = Convert.ToInt32(column);
            _player = player;
            _playerId = Convert.ToInt32(playerId);
            _towerId = Convert.ToInt32(towerId);
        }

        public override void Execute()
        {
            int towerKey = _player.GameHandler.Simulator.PlaceTower(row, column, _towerId, _player);
            if (towerKey >= 0)
            {
                foreach(var player in _player.GameHandler.Players)
                    player.QueueCommand(CmdPlaceTower.Construct(row.ToString(), column.ToString(), _playerId.ToString(), _towerId.ToString(), towerKey.ToString()));
            }
        }
    }
}
