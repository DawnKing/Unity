// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    /// 通知翻牌结果
    public sealed class NotifyTurnupResult : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TURNUP_RESULT;
        public short GetMsgType { get { return MsgType; } }
        public OneTurnupResult result;
        
        public static void Send(OneTurnupResult result, object className)
        {
            var packet = new NotifyTurnupResult
            {
                result = result
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
            result = new OneTurnupResult();
            result.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            result.WriteToStream(writer);
        }
    }
}
