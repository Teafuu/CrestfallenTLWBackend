using CrestfallenTLWBackend.Model.Core.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenCore.Communication;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Core.Commands.Lobby;

namespace CrestfallenTLWBackend.Model.Core
{
    public static class CommandFactory
    {
        // bad solution should be replaced !!
        public static Command CreateCommand(string[] cmd, Player player) => cmd[0] switch 
        {
            RequestChangeNickname.Tag => new RequestChangeNickname(cmd[1], player),
            RequestChangeReadyStatus.Tag => new RequestChangeReadyStatus(cmd[1], player),
            RequestChangeLobbyReadyStatus.Tag => new RequestChangeLobbyReadyStatus(cmd[1], player),
            RequestBroadcastMessageToChatroom.Tag => new RequestBroadcastMessageToChatroom(cmd[1], cmd[3], player),
            RequestCreateGrid.Tag => new RequestCreateGrid(player),

            CmdSetNickname.Tag => new CmdSetNickname(cmd[1], player),
            CmdEnterLobby.Tag => new CmdEnterLobby(cmd[1], player), // might and probably should be removed.
            CmdChangeReadyStatus.Tag => new CmdChangeReadyStatus(cmd[1], player),
            //CmdOnConnected.Tag => new CmdOnConnected(cmd[1], cmd[2], player),
            CmdChangeLobbyReadyStatus.Tag => new CmdChangeLobbyReadyStatus(cmd[1], cmd[2], player),
            CmdEnterGame.Tag => new CmdEnterGame(cmd[1], player),
            CmdCreateGrid.Tag => new CmdCreateGrid(cmd[1], cmd[2], player),
            CmdBroadcastMessageToChatroom.Tag => new CmdBroadcastMessageToChatroom(cmd[1], cmd[3], player),
            CmdAddLobbyPlayer.Tag => new CmdAddLobbyPlayer(cmd[1], cmd[2], cmd[3], player),
            _ => null
        };

    }
}
