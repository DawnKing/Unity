// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 通知冒险夺宝
    public sealed class NotifyRandStepMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RAND_STEP;
        public short GetMsgType { get { return MsgType; } }
        public const int NT_LOGIN = 1;//登陆通知
        public const int NT_RAND = 2;//夺宝通知
        public uint notifyType;// enum NOTIFY_TYPE
        public uint passStep;// 本次走过的步数
        
        public static void Send(uint notifyType, uint passStep, object className)
        {
            var packet = new NotifyRandStepMessage
            {
                notifyType = notifyType,
                passStep = passStep
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
            notifyType = reader.ReadUInt32();
            passStep = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(notifyType);
            writer.Write(passStep);
        }
    }
}