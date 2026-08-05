using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerChatEvent : Event, ICancellable
    {
        public UnturnedPlayer Player { get; }
        
        public Color Color { get; set; }
        
        public string Message { get; }
        
        public EChatMode ChatMode { get; }
        
        public bool Cancel { get; set; }
        
        public bool IsCancelled { get; set; }

        public PlayerChatEvent(UnturnedPlayer player, ref Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            Player = player;
            Color = color;
            Message = message;
            ChatMode = chatMode;
            Cancel = cancel;
        }
    }
}