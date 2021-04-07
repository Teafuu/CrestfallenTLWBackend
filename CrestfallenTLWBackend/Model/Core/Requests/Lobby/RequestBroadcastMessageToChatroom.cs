using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Requests
{
    public class RequestBroadcastMessageToChatroom : TRequestBroadcastMessageToChatroom
    {
        private string _chatroomId;
        private string _message;
        private Player _player;

        public RequestBroadcastMessageToChatroom(string chatroomId, string message, Player player)
        {
            _chatroomId = chatroomId;
            _message = message;
            _player = player;
        }

        public override void Execute()
        {
                Chatroom chatroom = _player.Chatrooms.Where(x => x.ID.ToString().Equals(_chatroomId)).FirstOrDefault();
                if (chatroom is null)
                    throw new Exception("User does not exist in chatroom");
                _player.QueueCommand(CmdBroadcastMessageToChatroom.Construct(chatroom.ID.ToString(), _player.Nickname, _message));
        }
    }
}
