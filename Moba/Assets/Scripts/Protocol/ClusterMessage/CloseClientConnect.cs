// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    // 关闭用户连接请求
    public sealed class CloseClientConnect : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLOSE_CLIENT_CONNECT;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new CloseClientConnect();
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
