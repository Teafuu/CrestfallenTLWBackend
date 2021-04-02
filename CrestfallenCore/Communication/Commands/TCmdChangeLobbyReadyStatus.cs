namespace CrestfallenCore.Communication.Commands
{
    public abstract class TCmdChangeLobbyReadyStatus : Command
    {
        public const string Tag = "CmdChangeLobbyReadyStatus";
        public static string Construct(string isLocal, string readyStatus) => $"{Tag}:{isLocal}:{readyStatus}";
    }
}
