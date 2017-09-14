// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SystemMessage
{
    // MSGTYPE_DECLARE(MSG_MARK_OBSERVER_NET_CONN),
    // 标记玩家链接附身状态
    public sealed class MarkObserverNetConnMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_MARK_OBSERVER_NET_CONN;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new MarkObserverNetConnMessage();
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