using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdBroadcastMessageToChatroom : TCmdBroadcastMessageToChatroom
    {
        private Player _player;
        private string _chatroomId;
        private string _message;
        public CmdBroadcastMessageToChatroom(string chatroomId, string message, Player player)
        {
            _player = player;
            _chatroomId = chatroomId;
            _message = message;
        }
        public override void Execute()
        {
            Chatroom chatroom = _player.Chatrooms
                .Where(x => x.ID.ToString().Equals(_chatroomId))
                .FirstOrDefault();

            foreach (var player in chatroom.Users)
                player.Output(Construct(_chatroomId, _player.Nickname, _message));
        }
    }
}
