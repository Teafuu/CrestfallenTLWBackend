﻿using CrestfallenTLWBackend.Model.Core.Requests;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenCore.Communication;

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

            CmdSetNickname.Tag => new CmdSetNickname(cmd[1], player),
            CmdEnterLobby.Tag => new CmdEnterLobby(cmd[1], cmd[2], player),
            CmdChangeReadyStatus.Tag => new CmdChangeReadyStatus(cmd[1], player),
            CmdOnConnected.Tag => new CmdOnConnected(cmd[1], cmd[2], player),
            CmdChangeLobbyReadyStatus.Tag => new CmdChangeLobbyReadyStatus(cmd[1], cmd[2], player),
            CmdEnterGame.Tag => new CmdEnterGame(player),
            CmdBroadcastMessageToChatroom.Tag => new CmdBroadcastMessageToChatroom(cmd[1], cmd[3], player),
            _ => null
        };

    }
}