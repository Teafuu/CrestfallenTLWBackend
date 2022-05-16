using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Controller.Gameplay;
using CrestfallenTLWBackend.Model.Core;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CrestfallenTLWBackend.Controller;

public class GameHandler
{
    public CommandHandler CommandHandler { get; set; }
    public List<Player> Players { get; private set;}
    public int GameIndex { get; private set; }
    public Chatroom LobbyChat { get; set; }
    public Grid Grid { get; set; }

    public GameSimulator Simulator { get; set; }

    private Thread _gameThread;
    public GameHandler(Player player1, Player player2, int gameIndex)
    {
        Logger.Log($"Game:{GameIndex}: Players {player1.Nickname}, {player2.Nickname}: have joined a lobby together.");

        CommandHandler = new CommandHandler(); 
        Players = new List<Player> { player1, player2 };
        LobbyChat = new Chatroom { ID = player1.ServerHandler.Chatrooms.Count, Users = Players };
        GameIndex = gameIndex;

        foreach (var player in Players) { 
            player.Chatrooms.Add(LobbyChat);
            player.GameHandler = this;
            player.IsReady = false;
        }

        _gameThread = new Thread(Initialize) { IsBackground = true };
        _gameThread.Start();
    }

    private void Initialize()
    {
        var shouldStart = false;

        CommandHandler.QueueCommand(TCmdEnterLobby.Construct(LobbyChat.ID.ToString()), Players[0]);
        CommandHandler.QueueCommand(TCmdEnterLobby.Construct(LobbyChat.ID.ToString()), Players[1]);

        //adding playerrs to lobby, temporary solution
        CommandHandler.QueueCommand(TCmdAddLobbyPlayer.Construct(Players[0].ID.ToString(), Players[0].Nickname, "true"), Players[0]);
        CommandHandler.QueueCommand(TCmdAddLobbyPlayer.Construct(Players[1].ID.ToString(), Players[1].Nickname, "false"), Players[0]);

        CommandHandler.QueueCommand(TCmdAddLobbyPlayer.Construct(Players[0].ID.ToString(), Players[0].Nickname, "false"), Players[1]);
        CommandHandler.QueueCommand(TCmdAddLobbyPlayer.Construct(Players[1].ID.ToString(), Players[1].Nickname, "true"), Players[1]);

        while (!shouldStart) // when both players have sent LobbyReadyStatusRequests
            if (Players.All(x => x.IsReady))
                shouldStart = true;

        StartGame();
    }
    private void StartGame()
    {
        Grid = new Grid();
        foreach (var player in Players)
            CommandHandler.QueueCommand(TCmdEnterGame.Construct(), player);
        Simulator = new GameSimulator(this, 25);
        Logger.Log($"Game:{GameIndex} has started");
    }
}