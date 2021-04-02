using CrestfallenCore.Communication;
using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdChangeReadyStatus : TCmdChangeReadyStatus
    {
        private Player _player;
        private string _isReady;
        public CmdChangeReadyStatus(string isReady, Player player)
        {
            _isReady = isReady;
            _player = player;
        }
        public override void Execute() => _player.Output(TCmdChangeReadyStatus.Construct(_isReady));
    }
}
