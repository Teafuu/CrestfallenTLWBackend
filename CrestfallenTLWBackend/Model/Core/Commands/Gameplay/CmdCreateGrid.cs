using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;


namespace CrestfallenTLWBackend.Model.Core.Commands.Gameplay
{
    class CmdCreateGrid : TCmdCreateGrid
    {
        private string _rows;
        private string _columns;
        private Player _player;

        public CmdCreateGrid(string rows, string columns, Player player)
        {
            _rows = rows;
            _columns = columns;
            _player = player;
        }

        public override void Execute() => _player.Output(Construct(_rows, _columns));
    }
}
