// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    public sealed class SelTankCount
    {
        public uint TankId;
        public uint Count;
        public void ReadFromStream(BinaryReader reader)
        {
            TankId = reader.ReadUInt32();
            Count = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TankId);
            writer.Write(Count);
        }
    }
}
