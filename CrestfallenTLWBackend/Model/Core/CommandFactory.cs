using CrestfallenTLWBackend.Model.Core.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenCore.Communication;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Core.Commands.Lobby;
using CrestfallenTLWBackend.Model.Core.Requests.Gameplay;
using CrestfallenCore.Communication.Requests;

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
            RequestSpawnUnit.Tag => new RequestSpawnUnit(cmd[1], player),
            RequestPlaceTower.Tag => new RequestPlaceTower(cmd[1], cmd[2], player, cmd[3]),

            CmdSetNickname.Tag => new CmdSetNickname(cmd[1], player),
            CmdEnterLobby.Tag => new CmdEnterLobby(cmd[1], player), // might and probably should be removed.
            CmdChangeReadyStatus.Tag => new CmdChangeReadyStatus(cmd[1], player),
            CmdUpdateUnitPositions.Tag => new CmdUpdateUnitPositions(cmd[1],cmd[2], player),
            CmdChangeLobbyReadyStatus.Tag => new CmdChangeLobbyReadyStatus(cmd[1], cmd[2], player),
            CmdEnterGame.Tag => new CmdEnterGame(player),
            CmdCreateGrid.Tag => new CmdCreateGrid(cmd[1], cmd[2], player),
            CmdBroadcastMessageToChatroom.Tag => new CmdBroadcastMessageToChatroom(cmd[1], cmd[3], player),
            CmdAddLobbyPlayer.Tag => new CmdAddLobbyPlayer(cmd[1], cmd[2], cmd[3], player),
            CmdSpawnUnit.Tag => new CmdSpawnUnit(cmd[1], cmd[2],cmd[3], cmd[4], cmd[5], player),
            CmdPlaceTower.Tag => new CmdPlaceTower(cmd[1], cmd[2], player, cmd[3]),
            _ => null
        };

    }
}
