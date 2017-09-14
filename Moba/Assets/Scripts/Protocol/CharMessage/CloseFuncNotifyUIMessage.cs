// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 关闭功能通知界面
    public sealed class CloseFuncNotifyUIMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLOSE_FUNC_NOTIFY_UI;
        public short GetMsgType { get { return MsgType; } }
        public uint uiType;// FUNC_NOTIFY_UI_TYPE
        
        public static void Send(uint uiType, object className)
        {
            var packet = new CloseFuncNotifyUIMessage
            {
                uiType = uiType
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
            uiType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(uiType);
        }
    }
}
