// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    /// 请求获取云购购买信息
    public sealed class RequestGetCloudPurchaseBuyInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_GET_CLOUD_PURCHASE_BUY_INFO;
        public short GetMsgType { get { return MsgType; } }
        public string charUuid;// 玩家UUID
        
        public static void Send(string charUuid, object className)
        {
            var packet = new RequestGetCloudPurchaseBuyInfoMessage
            {
                charUuid = charUuid
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
            charUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charUuid);
        }
    }
}
