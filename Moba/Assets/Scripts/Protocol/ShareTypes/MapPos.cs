// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ShareTypes
{
    // 地图位置信息
    public sealed class MapPos
    {
        public ushort x;// 坐标
        public ushort y;// 坐标
        public void ReadFromStream(BinaryReader reader)
        {
            x = reader.ReadUInt16();
            y = reader.ReadUInt16();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
        }
    }
}
