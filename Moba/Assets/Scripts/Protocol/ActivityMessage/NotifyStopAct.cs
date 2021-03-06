// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    //  通知停止活动(目前只在GM指令中使用)
    public sealed class NotifyStopAct : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_STOP_ACT;
        public short GetMsgType { get { return MsgType; } }
        public uint ActId;// 参见活动模板表，活动Id
        
        public static void Send(uint actId, object className)
        {
            var packet = new NotifyStopAct
            {
                ActId = actId
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
            ActId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ActId);
        }
    }
}
