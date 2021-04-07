using CrestfallenTLWBackend.Controller;
using CrestfallenTLWBackend.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public abstract class Player
    {
        public Player(ServerHandler server, int playerID)
        {
            ServerHandler = server;
            ID = playerID;
            Chatrooms = new List<Chatroom>();
        }
        public GameHandler GameHandler { get; set; }
        public ServerHandler ServerHandler { get; private set; }
        public List<Chatroom> Chatrooms { get; set; }
        public string Nickname { get; set; }
        public bool IsReady { get; set; }
        public int ID { get; private set; }
        public abstract void Receive();
        public abstract void Output(string msg);
        public abstract void QueueCommand(string command);
    }
}
