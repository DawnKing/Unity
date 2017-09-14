// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.WorldMessage
{
    public sealed class MapCountInfo
    {
        public int sector;// 地图id
        public int alllPlayerCount;// 地图玩家数量
        public void ReadFromStream(BinaryReader reader)
        {
            sector = reader.ReadInt32();
            alllPlayerCount = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sector);
            writer.Write(alllPlayerCount);
        }
    }
}