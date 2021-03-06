// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TankMessage
{
    // 通知掉落物品
    public sealed class NotifyDropItem : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_DROP_ITEM;
        public short GetMsgType { get { return MsgType; } }
        public ulong aiNpcGid;// 从哪个ainpc上掉落的
        public GiveItemStruct[] itemVec;// 掉落物品列表
        
        public static void Send(ulong aiNpcGid, GiveItemStruct[] itemVec, object className)
        {
            var packet = new NotifyDropItem
            {
                aiNpcGid = aiNpcGid,
                itemVec = itemVec
            };
            NetMessage.Send(packet.BuildPacket(), className);
        }
        
        public byte[] BuildPacket()
        {
            var buffer = ProtocolBuffer.Writer;
            buffer.Write(MsgType);
            buffer.Write(ProtocolBuffer.Zero);
            WriteToStream(buffer);
            return ProtocolBuffer.CacheStream.ToArray();
        }
        
        public void ReadFromStream(BinaryReader reader)
        {
            aiNpcGid = reader.ReadUInt64();
            var length2 = reader.ReadUInt16();
            itemVec = new GiveItemStruct[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                itemVec[i2] = new GiveItemStruct();
                itemVec[i2].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(aiNpcGid);
            ushort count2 = (ushort)(itemVec == null ? 0 : itemVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                itemVec[i2].WriteToStream(writer);
            }
        }
    }
}
