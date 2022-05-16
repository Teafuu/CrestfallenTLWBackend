using CrestfallenTLWBackend.Controller;

namespace CrestfallenTLWBackend.Model.Gameplay;

class TempPlayer : Player
{

    public TempPlayer(ServerHandler server, int playerID) : base(server, playerID) => Nickname = "Boten Anna";
    public override void Output(string msg) => IsReady = true;

    public override void QueueCommand(string command) { }

    public override void Receive() { }
}