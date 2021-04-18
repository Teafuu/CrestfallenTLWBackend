using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model.Core;
using CrestfallenTLWBackend.Model.Core.Commands;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller
{
    public class GameHandler
    {
        public CommandHandler CommandHandler { get; set; }
        public List<Player> Players { get; private set;}
        public int GameIndex { get; private set; }
        public Chatroom LobbyChat { get; set; }
        public Grid Grid { get; set; }

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

            _gameThread = new Thread(() => Initialize()) { IsBackground = true };
            _gameThread.Start();
        }

        private void Initialize()
        {
            bool shouldStart = false;

            CommandHandler.QueueCommand(CmdEnterLobby.Construct(Players[1].Nickname, LobbyChat.ID.ToString()), Players[0]);
            CommandHandler.QueueCommand(CmdEnterLobby.Construct(Players[0].Nickname, LobbyChat.ID.ToString()), Players[1]);
            CommandHandler.QueueCommand(CmdOnConnected.Construct(Players[0].ID.ToString(), "false"), Players[1]);
            CommandHandler.QueueCommand(CmdOnConnected.Construct(Players[1].ID.ToString(), "false"), Players[0]);

            while (!shouldStart) // when both players have sent LobbyReadyStatusRequests
                if (!Players.Where(x => !x.IsReady).Any())
                    shouldStart = true;

            StartGame();
        }
        private void StartGame()
        {
            Grid = new Grid();
            foreach (var player in Players)
                CommandHandler.QueueCommand(TCmdEnterGame.Construct((player == Players[0]).ToString()), player);
            
            Logger.Log($"Game:{GameIndex} has started");
        }
    }
}