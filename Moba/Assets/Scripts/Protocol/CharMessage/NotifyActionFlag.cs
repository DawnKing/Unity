// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 通知玩家行为开启
    public sealed class NotifyActionFlag : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ACTION_FLAG;
        public short GetMsgType { get { return MsgType; } }
        public uint ActionFlag;// enum CHAR_ACTION_FLAG_BIT
        
        public static void Send(uint actionFlag, object className)
        {
            var packet = new NotifyActionFlag
            {
                ActionFlag = actionFlag
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
            ActionFlag = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ActionFlag);
        }
    }
}
