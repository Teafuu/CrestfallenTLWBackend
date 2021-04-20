using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Commands.Lobby
{
    public class CmdAddLobbyPlayer : TCmdAddLobbyPlayer
    {
        private string _playerId;
        private string _nickname;
        private readonly string _isLocal;
        private Player _player;

        public CmdAddLobbyPlayer(string playerId, string nickname, string isLocal, Player player)
        {
            _playerId = playerId;
            _nickname = nickname;
            _isLocal = isLocal;
            _player = player;
        }
        public override void Execute() => _player.Output(Construct(_playerId, _nickname, _isLocal));
    }
}
