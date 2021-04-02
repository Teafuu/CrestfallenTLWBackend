using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public sealed class CmdSetNickname : TCmdSetNickname
    {
        private Player _player;
        private string _nick;
        public CmdSetNickname(string nick, Player player)
        {
            _nick = nick;
            _player = player;
        }
        public override void Execute() => _player.Output(Construct(_nick));
    }
}
