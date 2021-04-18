using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdEnterGame : TCmdEnterGame
    {
        private Player _player;
        private string _isPlayerOne;
        public CmdEnterGame(string isPlayerOne, Player player)
        {
            _player = player;
            _isPlayerOne = isPlayerOne;
        }
        public override void Execute() =>_player.Output(Construct(_isPlayerOne));
    }
}
