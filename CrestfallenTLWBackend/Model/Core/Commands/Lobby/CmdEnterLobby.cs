using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdEnterLobby : TCmdEnterLobby
    {
        private Player _player;
        private string _opponentNickname;
        private string _chatroomID;
        public CmdEnterLobby(string opponentNickname, string chatroomID, Player player)
        {
            _opponentNickname = opponentNickname;
            _chatroomID = chatroomID;
            _player = player;
        }
        public override void Execute()
        {
            _player.IsReady = false;
            _player.Output(Construct(_opponentNickname, _chatroomID));
        }
    }
}
