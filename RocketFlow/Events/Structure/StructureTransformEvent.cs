using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureTransformEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        public byte X { get; }
        public byte Y { get; }
        public uint InstanceID { get; }
        public Vector3 Point { get; set; }
        public byte AngleX { get; set; }
        public byte AngleY { get; set; }
        public byte AngleZ { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }

        public StructureTransformEvent(CSteamID instigator, byte x, byte y, uint instanceID, ref Vector3 point,
            ref byte angleX, ref byte angleY, ref byte angleZ, ref bool shouldAllow)
        {
            Instigator = instigator;
            X = x;
            Y = y;
            InstanceID = instanceID;
            Point = point;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
            ShouldAllow = shouldAllow;
        }
    }
}