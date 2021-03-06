// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    /// 给与物品的结构
    public sealed class GiveItemStruct
    {
        public uint nTemplateId;
        public int iCount;
        public byte bBind;
        public int iLifeTime;
        public void ReadFromStream(BinaryReader reader)
        {
            nTemplateId = reader.ReadUInt32();
            iCount = reader.ReadInt32();
            bBind = reader.ReadByte();
            iLifeTime = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nTemplateId);
            writer.Write(iCount);
            writer.Write(bBind);
            writer.Write(iLifeTime);
        }
    }
}
