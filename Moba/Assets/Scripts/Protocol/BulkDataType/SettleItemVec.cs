// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    public sealed class SettleItemVec
    {
        public uint Type;// 物品的奖励类型 BATTLE_SETTLE_TYPE
        public SettleItemInfo[] itemVec;// 奖励的物品信息
        public void ReadFromStream(BinaryReader reader)
        {
            Type = reader.ReadUInt32();
            var length2 = reader.ReadUInt16();
            itemVec = new SettleItemInfo[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                itemVec[i2] = new SettleItemInfo();
                itemVec[i2].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Type);
            ushort count2 = (ushort)(itemVec == null ? 0 : itemVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                itemVec[i2].WriteToStream(writer);
            }
        }
    }
}