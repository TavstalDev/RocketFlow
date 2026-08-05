using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureDeployEvent : Event, ICancellable
    {
        public SDG.Unturned.Structure Structure { get; }
        public ItemStructureAsset Asset { get; }
        public Vector3 Point { get; set; }
        public float AngleX { get; set; }
        public float AngleY { get; set; }
        public float AngleZ { get; set; }
        public ulong Owner { get; set; }
        public ulong Group { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public StructureDeployEvent(SDG.Unturned.Structure structure, ItemStructureAsset asset, ref Vector3 point, ref float angleX,
            ref float angleY, ref float angleZ, ref ulong owner, ref ulong group, ref bool shouldAllow)
        {
            Structure = structure;
            Asset = asset;
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