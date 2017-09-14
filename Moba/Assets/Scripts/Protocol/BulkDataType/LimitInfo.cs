// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    /// 玩家的限制信息
    public sealed class LimitInfo
    {
        public uint LimitId;// 限制id
        public int Count;// 当前数量
        public void ReadFromStream(BinaryReader reader)
        {
            LimitId = reader.ReadUInt32();
            Count = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(LimitId);
            writer.Write(Count);
        }
    }
}
