using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureRepairedEvent : Event
    {
        public CSteamID Instigator { get; }
        public Transform Transform { get; }
        public float TotalHealing { get; }

        public StructureRepairedEvent(CSteamID instigatorSteamID, Transform structureTransform, float totalHealing)
        {
            Instigator = instigatorSteamID;
            Transform = structureTransform;
            TotalHealing = totalHealing;
        }
    }
}