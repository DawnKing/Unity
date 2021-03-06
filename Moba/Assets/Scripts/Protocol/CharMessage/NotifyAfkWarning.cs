// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_AFK_WARNING)
    // track -> gate -> client  通知触发不良记录提示玩家
    public sealed class NotifyAfkWarning : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_AFK_WARNING;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new NotifyAfkWarning();
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
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
        }
    }
}
