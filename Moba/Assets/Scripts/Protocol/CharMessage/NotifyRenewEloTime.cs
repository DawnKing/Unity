// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // 通知客户端elo赛季刷新时间戳
    public sealed class NotifyRenewEloTime : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RENEW_ELO_TIME;
        public short GetMsgType { get { return MsgType; } }
        public uint sessionStartTime;// 本赛季开始时间
        public uint sessionEndTime;// 本赛季结束时间
        
        public static void Send(uint sessionStartTime, uint sessionEndTime, object className)
        {
            var packet = new NotifyRenewEloTime
            {
                sessionStartTime = sessionStartTime,
                sessionEndTime = sessionEndTime
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
            sessionStartTime = reader.ReadUInt32();
            sessionEndTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sessionStartTime);
            writer.Write(sessionEndTime);
        }
    }
}
