using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;


namespace CrestfallenTLWBackend.Model.Core.Commands.Gameplay
{
    class CmdPlaceTower : TCmdPlaceTower
    {
        private string _row;
        private string _col;
        private Player _player;
        private string _playerId;
        private string _towerId;
        private string _towerKey;

        public CmdPlaceTower(string row, string column, Player player, string playerId, string towerId, string towerKey)
        {
            _col = column;
            _row = row;
            _player = player;
            _playerId = playerId;
            _towerId = towerId;
            _towerKey = towerKey;
        }

        public override void Execute() => _player.Output(Construct(_row, _col, _playerId, _towerId, _towerKey));
    }
}
