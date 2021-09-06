using CrestfallenCore.Communication;
using CrestfallenTLWBackend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestfallenTLWBackend.Model.Core.Commands
{
    public class CmdNotFound : Command
    {
        private readonly string tag;
        public CmdNotFound(string tag) => this.tag = tag;
        public override void Execute() => Logger.Log($"Attempted to execute [NOT FOUND]: {tag}");
    }
}
