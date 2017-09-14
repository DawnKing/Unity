// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 请求拆解物品
    public sealed class RequestSplitItem : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_SPLIT_ITEM;
        public short GetMsgType { get { return MsgType; } }
        public uint contType;// enum CONTAINER_TYPE
        public short[] slotVec;// 该物品所在的格子
        
        public static void Send(uint contType, short[] slotVec, object className)
        {
            var packet = new RequestSplitItem
            {
                contType = contType,
                slotVec = slotVec
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
            contType = reader.ReadUInt32();
            var length2 = reader.ReadUInt16();
            slotVec = new short[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                slotVec[i2] = reader.ReadInt16();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(contType);
            ushort count2 = (ushort)(slotVec == null ? 0 : slotVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(slotVec[i2]);
            }
        }
    }
}