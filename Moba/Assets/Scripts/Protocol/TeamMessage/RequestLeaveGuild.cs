// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_LEAVE_GUILD),
    // 请求离开军团
    public sealed class RequestLeaveGuild : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_LEAVE_GUILD;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new RequestLeaveGuild();
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
