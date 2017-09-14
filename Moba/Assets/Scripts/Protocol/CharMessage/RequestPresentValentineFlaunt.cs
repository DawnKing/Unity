// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_PRESENT_VALENTINE_FLAUNT),
    // 请求赠送七夕鲜花
    public sealed class RequestPresentValentineFlaunt : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_PRESENT_VALENTINE_FLAUNT;
        public short GetMsgType { get { return MsgType; } }
        public string strName;/// 目标玩家
        public uint ItemId;/// 物品ID
        public uint ItemCount;/// 物品个数
        
        public static void Send(string strName, uint itemId, uint itemCount, object className)
        {
            var packet = new RequestPresentValentineFlaunt
            {
                strName = strName,
                ItemId = itemId,
                ItemCount = itemCount
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
            strName = reader.ReadString();
            ItemId = reader.ReadUInt32();
            ItemCount = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strName);
            writer.Write(ItemId);
            writer.Write(ItemCount);
        }
    }
}
