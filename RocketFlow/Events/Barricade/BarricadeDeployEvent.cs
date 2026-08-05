using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeDeployEvent : Event, ICancellable
    {
        public SDG.Unturned.Barricade Barricade { get; }
        
        public ItemBarricadeAsset Asset { get; }
        
        public Transform Hit { get; }
        
        public Vector3 Point { get; set; }
        
        public float AngleX { get; set; }
        
        public float AngleY { get; set; }
        
        public float AngleZ { get; set; }
        
        public ulong Owner { get; set; }
        
        public ulong Group { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public BarricadeDeployEvent(SDG.Unturned.Barricade barricade, ItemBarricadeAsset asset, Transform hit, ref Vector3 point,
            ref float angleX, ref float angleY, ref float angleZ, ref ulong owner, ref ulong group,
            ref bool shouldAllow)
        {
            Barricade = barricade;
            Asset = asset;
            Hit = hit;
            Point = point;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
            Owner = owner;
            Group = group;
            ShouldAllow = shouldAllow;
        }
    }
}