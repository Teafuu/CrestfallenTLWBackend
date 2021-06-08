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

        public CmdPlaceTower(string row, string column, Player player, string playerId)
        {
            _col = column;
            _row = row;
            _player = player;
            _playerId = playerId;
        }

        public override void Execute() => _player.Output(Construct(_row, _col, _playerId));
    }
}
