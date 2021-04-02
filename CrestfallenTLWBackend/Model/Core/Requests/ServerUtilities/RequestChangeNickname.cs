using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Requests
{
    public sealed class RequestChangeNickname : TRequestChangeNickname
    {
        private string _nick;
        private Player _player;
        public RequestChangeNickname(string nick, Player player)
        {
            _nick = nick;
            _player = player;
        }
        public override void Execute()
        {
            if(_nick.Length > 0)
            {
                _player.Nickname = _nick;
                _player.ServerHandler.CommandHandler.QueueCommand(CmdSetNickname.Construct(_nick), _player);
            }
        }
    }
}
