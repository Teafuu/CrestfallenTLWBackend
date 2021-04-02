using CrestfallenCore.Communication.Commands;
using CrestfallenCore.Communication.Requests;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Linq;

namespace CrestfallenTLWBackend.Model.Core.Requests
{
    public sealed class RequestChangeLobbyReadyStatus : TRequestChangeLobbyReadyStatus
    {
        private string _readyStatus;
        private Player _requester;

        public RequestChangeLobbyReadyStatus(string readyStatus, Player requester)
        {
            _readyStatus = readyStatus;
            _requester = requester;
        }

        public override void Execute()
        {
            try { 
                _requester.IsReady = _readyStatus.ToLower().Equals("true");// Get local player
                _requester.GameHandler.CommandHandler.QueueCommand(
                    TCmdChangeLobbyReadyStatus.Construct("true", _readyStatus),
                    _requester);

                _requester.GameHandler.CommandHandler.QueueCommand( // Get remote player
                    TCmdChangeLobbyReadyStatus.Construct("false", _readyStatus),
                    _requester.GameHandler.Players
                    .Where(x => x != _requester)
                    .FirstOrDefault());
            }
            catch(Exception e){
                Logger.Log(e.Message);
            }
        }
    }
}
