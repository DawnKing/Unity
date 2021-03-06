// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_RELIVE_SYNC_ATTR),
    // 坦克复活，请求同步坦克数值
    public sealed class ReliveSyncAttr : IProtocol
    {
        public const short MsgType = MessageType.MSG_RELIVE_SYNC_ATTR;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new ReliveSyncAttr();
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
