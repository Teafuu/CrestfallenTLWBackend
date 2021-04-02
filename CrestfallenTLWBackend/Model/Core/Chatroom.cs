using CrestfallenTLWBackend.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrestfallenTLWBackend.Model.Core
{
    public class Chatroom
    {
        public List<Player> Users { get; set; }
        public int ID { get; set; }
    }
}
