using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeRepairedEvent : Event
    {
        public CSteamID InstigatorSteamID { get; }
        
        public Transform BarricadeTransform { get; }
        
        public float PendingTotalHealing { get; }

        public BarricadeRepairedEvent(CSteamID instigatorSteamID, Transform barricadeTransform, float totalHealing)
        {
            InstigatorSteamID = instigatorSteamID;
            BarricadeTransform = barricadeTransform;
            PendingTotalHealing = totalHealing;
        }
    }
}