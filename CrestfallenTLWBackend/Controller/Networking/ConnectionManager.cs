using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Model;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller.Networking
{
    public class ConnectionManager
    {
        private TcpListener _listener;
        private Thread _listenerThread;
        private bool _shouldListen;
        private ServerHandler _server;
        public ConnectionManager(string host, int port, ServerHandler server)
        {
            IPAddress IP;
            _server = server;
            if(IPAddress.TryParse(host, out IP))
            {
                _listener = new TcpListener(IP, port);
                _listenerThread = new Thread(() => AcceptConnections()) { IsBackground = true };
                _listenerThread.Start();
            }
            else { 
                Logger.Log($"Invalid IP: {host}");
            }
        }

        private void AcceptConnections()
        {
            Logger.Log("Listener Started");
            _listener.Start();
            _shouldListen = true;
            while (_shouldListen)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Logger.Log($"Client connected with IP {client.Client.RemoteEndPoint}");
                Player player =  new HumanPlayer(client, _server, _server.Players.Count);
                //_server.CommandHandler.QueueCommand(TCmdOnConnected.Construct(player.ID.ToString(), "true"), player); might not be needed?
                _server.Players.Add(player);
            }
        }
    }
}
