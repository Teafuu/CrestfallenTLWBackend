using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core.Requests
{
    public sealed class RequestChangeReadyStatus : TRequestChangeReadyStatus
    {
        private string _readyStatus;
        private Player _player;
        public RequestChangeReadyStatus(string readyStatus, Player player)
        {
            _readyStatus = readyStatus;
            _player = player;
        }
        public override void Execute()
        {
            _player.IsReady = _readyStatus.ToLower().Equals("true");
            if (_player.IsReady)
                _player.ServerHandler.MatchmakingQueue.Add(_player);
            else _player.ServerHandler.MatchmakingQueue.Remove(_player);
            _player.ServerHandler.CommandHandler.QueueCommand(CmdChangeReadyStatus.Construct(_readyStatus), _player);
        }
    }
}
