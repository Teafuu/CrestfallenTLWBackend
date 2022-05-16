using CrestfallenCore.Communication;
using CrestfallenTLWBackend.Controller;
using CrestfallenTLWBackend.View;
using System;
using System.Net.Sockets;
using System.Threading;

namespace CrestfallenTLWBackend.Model.Gameplay;

public class HumanPlayer : Player
{
    private readonly TcpClient _client;

    private readonly Thread _receiveThread;
    public HumanPlayer(TcpClient client, ServerHandler server, int playerID) : base(server, playerID)
    {
        _client = client;
        _receiveThread = new Thread(Receive) { IsBackground = true };
        _receiveThread.Start();
    }

    public override void Output(string msg) => SocketCommunication.SendMessage(msg, _client.Client);

    public override void Receive()
    {
        while (_client.Connected)
        {
            try
            {
                var message = SocketCommunication.GetMessage(_client.Client);

                if(message == null)
                    continue;

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