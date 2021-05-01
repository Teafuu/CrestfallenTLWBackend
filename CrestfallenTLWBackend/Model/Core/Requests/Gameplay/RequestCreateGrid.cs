using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Requests
{
    class RequestCreateGrid : TRequestCreateGrid
    {
        private Player _player;
        public RequestCreateGrid (Player player)
        {
            _player = player;
        }

        public override void Execute()
        {
            _player.QueueCommand(CmdCreateGrid.Construct(_player.GameHandler.Grid.Rows.ToString(), _player.GameHandler.Grid.Columns.ToString()));
            
        }
    }
}
