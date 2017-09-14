// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    // 更新单个成就信息
    public sealed class NotifyAcemInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ACEM_INFO;
        public short GetMsgType { get { return MsgType; } }
        public AcemInfo acemInfo;
        
        public static void Send(AcemInfo acemInfo, object className)
        {
            var packet = new NotifyAcemInfo
            {
                acemInfo = acemInfo
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
            acemInfo = new AcemInfo();
            acemInfo.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            acemInfo.WriteToStream(writer);
        }
    }
}