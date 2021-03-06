// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 请求培养助手
    public sealed class RequestPlantBooster : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_BOOSTER_PLANT;
        public short GetMsgType { get { return MsgType; } }
        public short slot;// 助手格子
        public int expSlot;// 饲料格子
        
        public static void Send(short slot, int expSlot, object className)
        {
            var packet = new RequestPlantBooster
            {
                slot = slot,
                expSlot = expSlot
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
            slot = reader.ReadInt16();
            expSlot = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(slot);
            writer.Write(expSlot);
        }
    }
}
