using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeTransformEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        
        public byte X { get; }
        
        public byte Y { get; }
        
        public ushort Plant { get; }
        
        public uint InstanceID { get; }
        
        public Vector3 Point { get; set; }
        
        public byte AngleX { get; set; }
        
        public byte AngleY { get; set; }
        
        public byte AngleZ { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public BarricadeTransformEvent(CSteamID instigator, byte x, byte y, ushort plant, uint instanceID,
            ref Vector3 point, ref byte angleX, ref byte angleY, ref byte angleZ, ref bool shouldAllow)
        {
            Instigator = instigator;
            X = x;
            Y = y;
            Plant = plant;
            InstanceID = instanceID;
            Point = point;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
            ShouldAllow = shouldAllow;
            ShouldAllow = shouldAllow;
        }
    }
}