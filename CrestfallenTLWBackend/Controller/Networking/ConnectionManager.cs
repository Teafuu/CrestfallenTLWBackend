using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CrestfallenTLWBackend.Controller.Networking;

public class ConnectionManager
{
    private readonly TcpListener _listener;
    private readonly Thread _listenerThread;
    private bool _shouldListen;
    private readonly ServerHandler _server;
    public ConnectionManager(string host, int port, ServerHandler server)
    {
        _server = server;

        if(IPAddress.TryParse(host, out var ip))
        {
            _listener = new TcpListener(ip, port);
            _listenerThread = new Thread(AcceptConnections) { IsBackground = true };
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
            var client = _listener.AcceptTcpClient();
            Logger.Log($"Client connected with IP {client.Client.RemoteEndPoint}");
            Player player =  new HumanPlayer(client, _server, _server.Players.Count);
            _server.Players.Add(player);
        }
    }
}