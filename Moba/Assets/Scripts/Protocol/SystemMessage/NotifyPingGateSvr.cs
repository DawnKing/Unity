// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SystemMessage
{
    /// GateSvr - > Client 通知ping值
    public sealed class NotifyPingGateSvr : IProtocol
    {
        public const short MsgType = MessageType.MSG_GATE_NOTIFY_PING;
        public short GetMsgType { get { return MsgType; } }
        public ulong recvTime;// gateSvr收到消息的时间
        public uint time;// 服务器utc时间
        
        public static void Send(ulong recvTime, uint time, object className)
        {
            var packet = new NotifyPingGateSvr
            {
                recvTime = recvTime,
                time = time
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
            recvTime = reader.ReadUInt64();
            time = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(recvTime);
            writer.Write(time);
        }
    }
}
