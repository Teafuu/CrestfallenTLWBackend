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
        public CmdEnterGame(Player player) => _player = player;

        public override void Execute() =>_player.Output(Construct());
    }
}
