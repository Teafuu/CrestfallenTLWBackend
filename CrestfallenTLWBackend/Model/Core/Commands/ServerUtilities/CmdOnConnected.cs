using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public sealed class CmdOnConnected : TCmdOnConnected
    {
        private string _playerID;
        private string _isLocal;
        private Player _player;
        public CmdOnConnected(string playerID, string isLocal, Player player)
        {
            _playerID = playerID;
            _player = player;
            _isLocal = isLocal;
        }
        public override void Execute() => _player.Output(Construct(_playerID, _isLocal));
    }
}
