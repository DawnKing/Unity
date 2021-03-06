// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    /// 位置信息
    public sealed class SITE_DATA
    {
        public uint nCharOid;// 角色id
        public byte bStart;// 是否已经准备
        public byte bIsLoaded;// 地图加载完成
        public void ReadFromStream(BinaryReader reader)
        {
            nCharOid = reader.ReadUInt32();
            bStart = reader.ReadByte();
            bIsLoaded = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nCharOid);
            writer.Write(bStart);
            writer.Write(bIsLoaded);
        }
    }
}
