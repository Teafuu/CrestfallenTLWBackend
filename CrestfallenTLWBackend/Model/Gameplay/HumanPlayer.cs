using CrestfallenCore.Communication;
using CrestfallenTLWBackend.Controller;
using CrestfallenTLWBackend.Model.Core;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class HumanPlayer : Player
    {
        private TcpClient _client;

        private Thread _receiveThread;
        public HumanPlayer(TcpClient client, ServerHandler server, int playerID) : base(server, playerID)
        {
            _client = client;
            _receiveThread = new Thread(() => Receive()) { IsBackground = true };
            _receiveThread.Start();
        }

        public override void Output(string msg) => SocketCommunication.SendMessage(msg, _client.Client);

        public override void Receive()
        {
            while (_client.Connected)
            {
                try
                {
                    string message = SocketCommunication.GetMessage(_client.Client);
                    Logger.Log(message);
                    QueueCommand(message);
                }
                catch(Exception e) // handle exception
                {
                    Logger.Log(e.Message);
                    _client.Close();

                    ServerHandler?.Players.Remove(this);
                    ServerHandler?.MatchmakingQueue.Remove(this);
                    GameHandler?.Players.Remove(this);

                    _receiveThread.Join();
                }
            }
        }

        public override void QueueCommand(string command)
        {
            if (GameHandler != null)
                GameHandler.CommandHandler.QueueCommand(command, this);
            else ServerHandler.CommandHandler.QueueCommand(command, this);
        }
    }
}
