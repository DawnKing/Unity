// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    // 通知附身玩家打开界面
    public sealed class NotifyOpenUIMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_OPEN_UI;
        public short GetMsgType { get { return MsgType; } }
        public byte UIType;// enum UI_TYPE
        
        public static void Send(byte uIType, object className)
        {
            var packet = new NotifyOpenUIMessage
            {
                UIType = uIType
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
            UIType = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(UIType);
        }
    }
}
