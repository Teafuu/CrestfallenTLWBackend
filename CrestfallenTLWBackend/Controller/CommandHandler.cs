using CrestfallenCore.Communication;
using CrestfallenTLWBackend.Model;
using CrestfallenTLWBackend.Model.Core;
using CrestfallenTLWBackend.Model.Gameplay;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrestfallenTLWBackend.Controller
{
    public class CommandHandler
    {
        private bool _isActive;
        private Queue<Command> CommandQueue { get; set; }
        public Thread CommandThread { get; set; }
        public CommandHandler()
        {
            CommandQueue = new Queue<Command>();
            CommandThread = new Thread(() => ExecuteCommands()) { IsBackground = true };
            CommandThread.Start();
        }

        private void ExecuteCommands()
        {
            _isActive = true;
            Logger.Log("Command handler started");

            while (_isActive)
            {
                while(CommandQueue.Count > 0)
                {
                    try { 
                        Command cmd = CommandQueue.Dequeue();
                        Logger.Log($"Executing {cmd}");
                        cmd?.Execute();
                    }
                    catch(Exception e)
                    {
                        Logger.Log(e.Message);
                    }
                }
            }
        }

        public void QueueCommand(string cmd, Player player)
        {
            try {
                if (cmd != null && player != null)
                    CommandQueue?.Enqueue(CommandFactory.CreateCommand(cmd?.Split(':'), player));
                else throw new ArgumentNullException();
            }
            catch(Exception e)
            {
                Logger.Log(e.Message);
            }
        }
    }
}
