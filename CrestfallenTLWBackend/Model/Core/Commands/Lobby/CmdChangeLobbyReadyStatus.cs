using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdChangeLobbyReadyStatus : TCmdChangeLobbyReadyStatus
    {
        private Player _player;
        private string _isReady;
        private string _isLocal;
        public CmdChangeLobbyReadyStatus(string isLocal, string isReady, Player player)
        {
            _isReady = isReady;
            _player = player;
            _isLocal = isLocal;
        }
        public override void Execute() => _player.Output(Construct(_isLocal, _isReady));
    }
}
