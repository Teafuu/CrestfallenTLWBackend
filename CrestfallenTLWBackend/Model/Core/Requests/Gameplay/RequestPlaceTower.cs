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
        private string _playerId;
        private string _towerId;
        private string _towerKey;
        public RequestPlaceTower(string row, string column, Player player, string playerId, string towerId, string towerKey)
        {
            this.row = Convert.ToInt32(row);
            this.column = Convert.ToInt32(column);
            _player = player;
            _playerId = playerId;
            _towerId = towerId;
            _towerKey = towerKey;
        }

        public override void Execute()
        {
            if(_player.GameHandler.Simulator.PlaceTower(row, column, 0, _player))
            {
                foreach(var player in _player.GameHandler.Players)
                    player.QueueCommand(CmdPlaceTower.Construct(row.ToString(), column.ToString(), _playerId, _towerId, _towerKey));
            }
        }
    }
}
