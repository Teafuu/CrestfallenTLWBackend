using CrestfallenTLWBackend.Controller.Networking;
using CrestfallenTLWBackend.Model.Core;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller
{
    public class ServerHandler
    {
        public CommandHandler CommandHandler { get; private set; }
        public List<Player> Players { get; set;}
        public List<Player> MatchmakingQueue { get; set; }
        public List<GameHandler> ActiveGames { get; private set; }
        public List<Chatroom> Chatrooms { get; set; } = new List<Chatroom>();

        private bool _isActive;
        private ConnectionManager _connectionManager;
        private Thread _matchmakingThread;
        public ServerHandler()
        {
            Players = new List<Player>();
            Players.Add(new TempPlayer(this,5));
            MatchmakingQueue = new List<Player>();
            MatchmakingQueue.Add(Players[0]);
            ActiveGames = new List<GameHandler>();
            CommandHandler = new CommandHandler();
            _connectionManager = new ConnectionManager("88.86.36.163", 8000, this);

            _matchmakingThread = new Thread(() => MatchMaker()) { IsBackground = true };
            _matchmakingThread.Start();
            while (true)
            {
                Console.ReadLine();
                Logger.SaveLogs();
                break;
            }
        }
        public void MatchMaker()
        {
            _isActive = true;
            while (_isActive)
            {
                if(MatchmakingQueue.Count > 1)
                {
                    ActiveGames.Add(new GameHandler(MatchmakingQueue[0], MatchmakingQueue[1], ActiveGames.Count + 1));
                    MatchmakingQueue.RemoveAt(0);
                    MatchmakingQueue.RemoveAt(0);
                }
            }
        }
    }
}
